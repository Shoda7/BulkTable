using System.Diagnostics;

namespace BulkTable
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void pnlAreaArquivo_DragEnter(object sender, DragEventArgs e)
        {
            // Verifica se o objeto sendo arrastado é um arquivo
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Se for, muda o cursor para o ícone de 'copiar'
                e.Effect = DragDropEffects.Copy;

                pnlAreaArquivo.BackColor = System.Drawing.Color.FromArgb(255, 200, 230, 201);
            }
            else
            {
                // Caso contrário, mostra que não é permitido
                e.Effect = DragDropEffects.None;
            }
        }

        private void pnlAreaArquivo_DragDrop(object sender, DragEventArgs e)
        {
            // Obtém o caminho do arquivo que foi solto
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                // Define o texto do TextBox para o caminho do primeiro arquivo
                //textBoxFilePath.Text = files[0];
                MessageBox.Show(files[0]);
            }
        }

        private void pnlAreaArquivo_DragLeave(object sender, EventArgs e)
        {
            // Reverte a cor de fundo para a cor padrão ou a cor que você definiu inicialmente
            pnlAreaArquivo.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        private void btnBuscarArquivo_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância da caixa de diálogo
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Define um filtro para mostrar apenas arquivos específicos
            openFileDialog.Filter = "Arquivos XLSX e CSV (*.xlsx;*.csv)|*.xlsx;*.csv|Todos os arquivos (*.*)|*.*";

            // Define o título da caixa de diálogo
            openFileDialog.Title = "Selecione o arquivo para importação";

            // Define se a caixa de diálogo lembra o último diretório usado
            openFileDialog.RestoreDirectory = true;

            // Exibe a caixa de diálogo
            DialogResult result = openFileDialog.ShowDialog();

            // Verifica se o usuário selecionou um arquivo e clicou em OK
            if (result == DialogResult.OK)
            {
                // Pega o caminho completo do arquivo selecionado
                string selectedFilePath = openFileDialog.FileName;

                // Aqui você pode usar o caminho do arquivo para o seu bulk insert
                MessageBox.Show($"Arquivo selecionado: {selectedFilePath}");
            }
        }
    }
}
