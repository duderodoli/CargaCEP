namespace CargaCEP.Forms
{
    partial class FormularioImportacaoArquivo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAbrirDialogoArquivo = new System.Windows.Forms.Button();
            this.ofdCaixaProcuraArquivo = new System.Windows.Forms.OpenFileDialog();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.txtNomeArquivo = new System.Windows.Forms.RichTextBox();
            this.listBoxErros = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAbrirDialogoArquivo
            // 
            this.btnAbrirDialogoArquivo.Location = new System.Drawing.Point(7, 62);
            this.btnAbrirDialogoArquivo.Name = "btnAbrirDialogoArquivo";
            this.btnAbrirDialogoArquivo.Size = new System.Drawing.Size(89, 33);
            this.btnAbrirDialogoArquivo.TabIndex = 0;
            this.btnAbrirDialogoArquivo.Text = "Procurar";
            this.btnAbrirDialogoArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirDialogoArquivo.Click += new System.EventHandler(this.btnAbrirDialogoArquivo_Click);
            // 
            // ofdCaixaProcuraArquivo
            // 
            this.ofdCaixaProcuraArquivo.InitialDirectory = "C:\\";
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(701, 62);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(89, 33);
            this.btnProcessar.TabIndex = 1;
            this.btnProcessar.Text = "Processar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // txtNomeArquivo
            // 
            this.txtNomeArquivo.BackColor = System.Drawing.SystemColors.Window;
            this.txtNomeArquivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeArquivo.Location = new System.Drawing.Point(102, 62);
            this.txtNomeArquivo.Name = "txtNomeArquivo";
            this.txtNomeArquivo.ReadOnly = true;
            this.txtNomeArquivo.Size = new System.Drawing.Size(593, 33);
            this.txtNomeArquivo.TabIndex = 10;
            this.txtNomeArquivo.Text = "";
            this.txtNomeArquivo.WordWrap = false;
            this.txtNomeArquivo.TextChanged += new System.EventHandler(this.txtNomeArquivo_TextChanged);
            // 
            // listBoxErros
            // 
            this.listBoxErros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxErros.ForeColor = System.Drawing.Color.Red;
            this.listBoxErros.FormattingEnabled = true;
            this.listBoxErros.HorizontalScrollbar = true;
            this.listBoxErros.ItemHeight = 20;
            this.listBoxErros.Location = new System.Drawing.Point(12, 127);
            this.listBoxErros.Name = "listBoxErros";
            this.listBoxErros.Size = new System.Drawing.Size(917, 244);
            this.listBoxErros.TabIndex = 11;
            this.listBoxErros.Visible = false;
            // 
            // FormularioImportacaoArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 404);
            this.Controls.Add(this.listBoxErros);
            this.Controls.Add(this.txtNomeArquivo);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.btnAbrirDialogoArquivo);
            this.Name = "FormularioImportacaoArquivo";
            this.Text = "Importação Base CEP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirDialogoArquivo;
        private System.Windows.Forms.OpenFileDialog ofdCaixaProcuraArquivo;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.RichTextBox txtNomeArquivo;
        private System.Windows.Forms.ListBox listBoxErros;
    }
}

