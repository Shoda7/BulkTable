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
            // Verifica se o objeto sendo arrastado � um arquivo
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Se for, muda o cursor para o �cone de 'copiar'
                e.Effect = DragDropEffects.Copy;

                pnlAreaArquivo.BackColor = System.Drawing.Color.FromArgb(255, 200, 230, 201);
            }
            else
            {
                // Caso contr�rio, mostra que n�o � permitido
                e.Effect = DragDropEffects.None;
            }
        }

        private void pnlAreaArquivo_DragDrop(object sender, DragEventArgs e)
        {
            // Obt�m o caminho do arquivo que foi solto
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
            // Reverte a cor de fundo para a cor padr�o ou a cor que voc� definiu inicialmente
            pnlAreaArquivo.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        private void btnBuscarArquivo_Click(object sender, EventArgs e)
        {
            // Cria uma nova inst�ncia da caixa de di�logo
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Define um filtro para mostrar apenas arquivos espec�ficos
            openFileDialog.Filter = "Arquivos XLSX e CSV (*.xlsx;*.csv)|*.xlsx;*.csv|Todos os arquivos (*.*)|*.*";

            // Define o t�tulo da caixa de di�logo
            openFileDialog.Title = "Selecione o arquivo para importa��o";

            // Define se a caixa de di�logo lembra o �ltimo diret�rio usado
            openFileDialog.RestoreDirectory = true;

            // Exibe a caixa de di�logo
            DialogResult result = openFileDialog.ShowDialog();

            // Verifica se o usu�rio selecionou um arquivo e clicou em OK
            if (result == DialogResult.OK)
            {
                // Pega o caminho completo do arquivo selecionado
                string selectedFilePath = openFileDialog.FileName;

                // Aqui voc� pode usar o caminho do arquivo para o seu bulk insert
                MessageBox.Show($"Arquivo selecionado: {selectedFilePath}");
            }
        }
    }
}
