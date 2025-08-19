namespace BulkTable
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlAreaArquivo = new Panel();
            btnBuscarArquivo = new Button();
            lblOu = new Label();
            lblSolteArquivo = new Label();
            pictureBox1 = new PictureBox();
            btnAnalisarArquivos = new Button();
            chkColunasArquivo = new CheckedListBox();
            txtFilePath = new TextBox();
            txtNomeTabela = new TextBox();
            btnGerarTabelaBD = new Button();
            pnlAreaArquivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlAreaArquivo
            // 
            pnlAreaArquivo.AllowDrop = true;
            pnlAreaArquivo.BorderStyle = BorderStyle.FixedSingle;
            pnlAreaArquivo.Controls.Add(btnBuscarArquivo);
            pnlAreaArquivo.Controls.Add(lblOu);
            pnlAreaArquivo.Controls.Add(lblSolteArquivo);
            pnlAreaArquivo.Controls.Add(pictureBox1);
            pnlAreaArquivo.Location = new Point(12, 13);
            pnlAreaArquivo.Margin = new Padding(3, 4, 3, 4);
            pnlAreaArquivo.Name = "pnlAreaArquivo";
            pnlAreaArquivo.Size = new Size(546, 297);
            pnlAreaArquivo.TabIndex = 1;
            pnlAreaArquivo.DragDrop += pnlAreaArquivo_DragDrop;
            pnlAreaArquivo.DragEnter += pnlAreaArquivo_DragEnter;
            pnlAreaArquivo.DragLeave += pnlAreaArquivo_DragLeave;
            // 
            // btnBuscarArquivo
            // 
            btnBuscarArquivo.Location = new Point(189, 229);
            btnBuscarArquivo.Margin = new Padding(3, 4, 3, 4);
            btnBuscarArquivo.Name = "btnBuscarArquivo";
            btnBuscarArquivo.Size = new Size(142, 52);
            btnBuscarArquivo.TabIndex = 2;
            btnBuscarArquivo.Text = "Buscar Arquivo";
            btnBuscarArquivo.UseVisualStyleBackColor = true;
            btnBuscarArquivo.Click += btnBuscarArquivo_Click;
            // 
            // lblOu
            // 
            lblOu.AutoSize = true;
            lblOu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOu.Location = new Point(247, 184);
            lblOu.Name = "lblOu";
            lblOu.Size = new Size(30, 23);
            lblOu.TabIndex = 3;
            lblOu.Text = "ou";
            // 
            // lblSolteArquivo
            // 
            lblSolteArquivo.AutoSize = true;
            lblSolteArquivo.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSolteArquivo.Location = new Point(171, 119);
            lblSolteArquivo.Name = "lblSolteArquivo";
            lblSolteArquivo.Size = new Size(200, 37);
            lblSolteArquivo.TabIndex = 2;
            lblSolteArquivo.Text = "Solte o Arquivo";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.clound_upload;
            pictureBox1.InitialImage = Properties.Resources.clound_upload;
            pictureBox1.Location = new Point(202, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(114, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnAnalisarArquivos
            // 
            btnAnalisarArquivos.Location = new Point(12, 530);
            btnAnalisarArquivos.Margin = new Padding(3, 4, 3, 4);
            btnAnalisarArquivos.Name = "btnAnalisarArquivos";
            btnAnalisarArquivos.Size = new Size(142, 52);
            btnAnalisarArquivos.TabIndex = 4;
            btnAnalisarArquivos.Text = "Analisar Arquivos";
            btnAnalisarArquivos.UseVisualStyleBackColor = true;
            btnAnalisarArquivos.Click += btnAnalisarArquivos_Click;
            // 
            // chkColunasArquivo
            // 
            chkColunasArquivo.FormattingEnabled = true;
            chkColunasArquivo.Location = new Point(849, 13);
            chkColunasArquivo.Name = "chkColunasArquivo";
            chkColunasArquivo.Size = new Size(290, 290);
            chkColunasArquivo.TabIndex = 5;
            // 
            // txtFilePath
            // 
            txtFilePath.Enabled = false;
            txtFilePath.Location = new Point(12, 317);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(546, 27);
            txtFilePath.TabIndex = 6;
            // 
            // txtNomeTabela
            // 
            txtNomeTabela.Location = new Point(849, 309);
            txtNomeTabela.Name = "txtNomeTabela";
            txtNomeTabela.Size = new Size(290, 27);
            txtNomeTabela.TabIndex = 7;
            // 
            // btnGerarTabelaBD
            // 
            btnGerarTabelaBD.Location = new Point(870, 382);
            btnGerarTabelaBD.Margin = new Padding(3, 4, 3, 4);
            btnGerarTabelaBD.Name = "btnGerarTabelaBD";
            btnGerarTabelaBD.Size = new Size(142, 52);
            btnGerarTabelaBD.TabIndex = 8;
            btnGerarTabelaBD.Text = "Gerar Tabela";
            btnGerarTabelaBD.UseVisualStyleBackColor = true;
            btnGerarTabelaBD.Click += btnGerarTabelaBD_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 709);
            Controls.Add(btnGerarTabelaBD);
            Controls.Add(txtNomeTabela);
            Controls.Add(txtFilePath);
            Controls.Add(chkColunasArquivo);
            Controls.Add(btnAnalisarArquivos);
            Controls.Add(pnlAreaArquivo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmPrincipal";
            Text = "Home";
            pnlAreaArquivo.ResumeLayout(false);
            pnlAreaArquivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlAreaArquivo;
        private PictureBox pictureBox1;
        private Label lblSolteArquivo;
        private Label lblOu;
        private Button btnBuscarArquivo;
        private Button btnAnalisarArquivos;
        private CheckedListBox chkColunasArquivo;
        private TextBox txtFilePath;
        private TextBox txtNomeTabela;
        private Button btnGerarTabelaBD;
    }
}
