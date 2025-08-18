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
            pnlAreaArquivo.Location = new Point(66, 22);
            pnlAreaArquivo.Name = "pnlAreaArquivo";
            pnlAreaArquivo.Size = new Size(251, 223);
            pnlAreaArquivo.TabIndex = 1;
            pnlAreaArquivo.DragDrop += pnlAreaArquivo_DragDrop;
            pnlAreaArquivo.DragEnter += pnlAreaArquivo_DragEnter;
            pnlAreaArquivo.DragLeave += pnlAreaArquivo_DragLeave;
            // 
            // btnBuscarArquivo
            // 
            btnBuscarArquivo.Location = new Point(60, 172);
            btnBuscarArquivo.Name = "btnBuscarArquivo";
            btnBuscarArquivo.Size = new Size(124, 39);
            btnBuscarArquivo.TabIndex = 2;
            btnBuscarArquivo.Text = "Buscar Arquivo";
            btnBuscarArquivo.UseVisualStyleBackColor = true;
            btnBuscarArquivo.Click += btnBuscarArquivo_Click;
            // 
            // lblOu
            // 
            lblOu.AutoSize = true;
            lblOu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOu.Location = new Point(111, 138);
            lblOu.Name = "lblOu";
            lblOu.Size = new Size(23, 17);
            lblOu.TabIndex = 3;
            lblOu.Text = "ou";
            // 
            // lblSolteArquivo
            // 
            lblSolteArquivo.AutoSize = true;
            lblSolteArquivo.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSolteArquivo.Location = new Point(45, 89);
            lblSolteArquivo.Name = "lblSolteArquivo";
            lblSolteArquivo.Size = new Size(155, 30);
            lblSolteArquivo.TabIndex = 2;
            lblSolteArquivo.Text = "Solte o Arquivo";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.clound_upload;
            pictureBox1.InitialImage = Properties.Resources.clound_upload;
            pictureBox1.Location = new Point(72, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 300);
            Controls.Add(pnlAreaArquivo);
            Name = "FrmPrincipal";
            Text = "Home";
            pnlAreaArquivo.ResumeLayout(false);
            pnlAreaArquivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAreaArquivo;
        private PictureBox pictureBox1;
        private Label lblSolteArquivo;
        private Label lblOu;
        private Button btnBuscarArquivo;
    }
}
