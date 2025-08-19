using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using OfficeOpenXml;
using ClosedXML.Excel;
using System.Drawing.Text;
using Microsoft.Data.SqlClient;

namespace BulkTable
{
    public partial class FrmPrincipal : Form
    {
        private string _filePath { get; set; }
        private DataTable _dataTable { get; set; }

        private string _connectionString = "Server=localhost;Database=SeuBancoDeDados;Integrated Security=True;";
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
                _filePath = txtFilePath.Text = files[0];
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

            openFileDialog.Title = "Selecione o arquivo para importa��o";

            openFileDialog.RestoreDirectory = true;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _filePath = txtFilePath.Text = openFileDialog.FileName;
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
                throw new NotSupportedException("Formato de arquivo n�o suportado. Apenas .xlsx e .csv s�o permitidos.");
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
                // L� o cabe�alho
                csv.Read();
                csv.ReadHeader();

                // Adiciona as colunas do DataTable com base no cabe�alho
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
                ExibirColunas(_dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExibirColunas(DataTable dataTable)
        {
            chkColunasArquivo.Items.Clear();

            foreach (DataColumn column in dataTable.Columns)
            {
                chkColunasArquivo.Items.Add(column.ColumnName, true);
            }
        }

        private void btnGerarTabelaBD_Click(object sender, EventArgs e)
        {
            string nomeBD = DefinirNomeTabela();

            CriarTabela(nomeBD);

        }

        private void CriarTabela(string nomeBD)
        {
            // Verifica se h� colunas selecionadas
            if (chkColunasArquivo.CheckedItems.Count == 0)
            {
                MessageBox.Show("Nenhuma coluna foi selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construir a parte da declara��o SQL com as colunas
            var colunasSql = new System.Text.StringBuilder();

            foreach (var item in chkColunasArquivo.CheckedItems)
            {
                // Pega o nome da coluna selecionada
                string nomeColuna = item.ToString();

                // Adiciona a coluna com um tipo de dado gen�rico
                colunasSql.Append($"[{nomeColuna}] NVARCHAR(255), ");
            }

            // Remove a �ltima v�rgula e o espa�o extra
            colunasSql.Length = colunasSql.Length - 2;

            // Monta o comando SQL completo
            string sql = $"CREATE TABLE [dbo].[{nomeBD}] ({colunasSql.ToString()})";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery(); // Executa o comando
                    }
                }
                MessageBox.Show($"Tabela '{nomeBD}' criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar a tabela: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DefinirNomeTabela()
        {
            if (string.IsNullOrEmpty(txtNomeTabela.Text))
            {
                string bdName = "TEMP_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                txtNomeTabela.Text = bdName;
                return bdName;
            }
            else
            {
                if (txtNomeTabela.Text.Length > 30)
                {
                    MessageBox.Show("O nome da tabela n�o pode exceder 30 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(txtNomeTabela.Text, @"^[a-zA-Z0-9_]+$"))
                {
                    MessageBox.Show("O nome da tabela s� pode conter letras, n�meros e underscores.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                else if (char.IsDigit(txtNomeTabela.Text[0]))
                {
                    MessageBox.Show("O nome da tabela n�o pode come�ar com um n�mero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                if (txtNomeTabela.Text.StartsWith("GRC") || txtNomeTabela.Text.StartsWith("TMP") || txtNomeTabela.Text.StartsWith("COB") || txtNomeTabela.Text.StartsWith("GIS"))
                {
                    MessageBox.Show("O nome da tabela n�o pode come�ar com esse prefixo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                else
                {
                    return txtNomeTabela.Text;
                }
            }
        }
    }
}
