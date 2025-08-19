using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using OfficeOpenXml;
using ClosedXML.Excel;

namespace BulkTable
{
    public partial class FrmPrincipal : Form
    {
        private string _filePath { get; set; }
        private DataTable _dataTable { get; set; }
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void pnlAreaArquivo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;

                pnlAreaArquivo.BackColor = System.Drawing.Color.FromArgb(255, 200, 230, 201);
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pnlAreaArquivo_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                _filePath = files[0];
            }
        }

        private void pnlAreaArquivo_DragLeave(object sender, EventArgs e)
        {
            pnlAreaArquivo.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        private void btnBuscarArquivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Arquivos XLSX e CSV (*.xlsx;*.csv)|*.xlsx;*.csv|Todos os arquivos (*.*)|*.*";

            openFileDialog.Multiselect = false;

            openFileDialog.Title = "Selecione o arquivo para importação";

            openFileDialog.RestoreDirectory = true;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _filePath = openFileDialog.FileName;
            }
        }
        private DataTable CarregarDadosDoArquivo(string filePath)
        {
            DataTable dt = new DataTable();
            string extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".xlsx")
            {
                dt = LerExcel(filePath);
            }
            else if (extension == ".csv")
            {
                dt = LerCsv(filePath);
            }
            else
            {
                throw new NotSupportedException("Formato de arquivo não suportado. Apenas .xlsx e .csv são permitidos.");
            }

            return dt;
        }

        private DataTable LerExcel(string filePath)
        {
            DataTable dt = new DataTable();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.FirstOrDefault();

                if (worksheet == null)
                {
                    throw new InvalidOperationException("Nenhuma planilha encontrada no arquivo Excel.");
                }

                var range = worksheet.RangeUsed();

                dt = range.AsTable().AsNativeDataTable();
            }

            return dt;
        }

        private DataTable LerCsv(string filePath)
        {
            DataTable dt = new DataTable();
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";", // Ou ',' dependendo do seu arquivo CSV
                BadDataFound = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                // Lê o cabeçalho
                csv.Read();
                csv.ReadHeader();

                // Adiciona as colunas do DataTable com base no cabeçalho
                foreach (var header in csv.HeaderRecord)
                {
                    dt.Columns.Add(header);
                }

                // Adiciona as linhas
                while (csv.Read())
                {
                    var record = csv.GetRecord<dynamic>();
                    var newRow = dt.NewRow();

                    foreach (var prop in (IDictionary<string, object>)record)
                    {
                        newRow[prop.Key] = prop.Value;
                    }
                    dt.Rows.Add(newRow);
                }
            }

            return dt;
        }

        private void btnAnalisarArquivos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                MessageBox.Show("Por favor, selecione um arquivo primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _dataTable = CarregarDadosDoArquivo(_filePath);
                MessageBox.Show("Arquivo carregado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
