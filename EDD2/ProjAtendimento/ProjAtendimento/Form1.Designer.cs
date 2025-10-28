namespace ProjAtendimento
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.ListBox listBoxSenhas;
        private System.Windows.Forms.Button btnListarSenhas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.NumericUpDown numericUpDownGuiche;
        private System.Windows.Forms.Button btnChamar;
        private System.Windows.Forms.ListBox listBoxAtendimentos;
        private System.Windows.Forms.Button btnListarAtendimentos;
        private System.Windows.Forms.Label labelGuiche;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGerar = new System.Windows.Forms.Button();
            this.listBoxSenhas = new System.Windows.Forms.ListBox();
            this.btnListarSenhas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQtde = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.numericUpDownGuiche = new System.Windows.Forms.NumericUpDown();
            this.btnChamar = new System.Windows.Forms.Button();
            this.listBoxAtendimentos = new System.Windows.Forms.ListBox();
            this.btnListarAtendimentos = new System.Windows.Forms.Button();
            this.labelGuiche = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGuiche)).BeginInit();
            this.SuspendLayout();
            this.btnGerar.Location = new System.Drawing.Point(12, 12);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 27);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            this.listBoxSenhas.FormattingEnabled = true;
            this.listBoxSenhas.ItemHeight = 16;
            this.listBoxSenhas.Location = new System.Drawing.Point(12, 45);
            this.listBoxSenhas.Name = "listBoxSenhas";
            this.listBoxSenhas.Size = new System.Drawing.Size(240, 196);
            this.listBoxSenhas.TabIndex = 1;
            this.btnListarSenhas.Location = new System.Drawing.Point(12, 247);
            this.btnListarSenhas.Name = "btnListarSenhas";
            this.btnListarSenhas.Size = new System.Drawing.Size(240, 30);
            this.btnListarSenhas.TabIndex = 2;
            this.btnListarSenhas.Text = "Listar senhas";
            this.btnListarSenhas.UseVisualStyleBackColor = true;
            this.btnListarSenhas.Click += new System.EventHandler(this.btnListarSenhas_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Qtde guichês";
            this.lblQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblQtde.Location = new System.Drawing.Point(283, 102);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(90, 40);
            this.lblQtde.TabIndex = 4;
            this.lblQtde.Text = "0";
            this.lblQtde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdicionar.Location = new System.Drawing.Point(290, 145);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 28);
            this.btnAdicionar.TabIndex = 5;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            this.numericUpDownGuiche.Location = new System.Drawing.Point(445, 18);
            this.numericUpDownGuiche.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGuiche.Name = "numericUpDownGuiche";
            this.numericUpDownGuiche.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownGuiche.TabIndex = 6;
            this.numericUpDownGuiche.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.btnChamar.Location = new System.Drawing.Point(520, 12);
            this.btnChamar.Name = "btnChamar";
            this.btnChamar.Size = new System.Drawing.Size(75, 30);
            this.btnChamar.TabIndex = 7;
            this.btnChamar.Text = "Chamar";
            this.btnChamar.UseVisualStyleBackColor = true;
            this.btnChamar.Click += new System.EventHandler(this.btnChamar_Click);
            this.listBoxAtendimentos.FormattingEnabled = true;
            this.listBoxAtendimentos.ItemHeight = 16;
            this.listBoxAtendimentos.Location = new System.Drawing.Point(396, 45);
            this.listBoxAtendimentos.Name = "listBoxAtendimentos";
            this.listBoxAtendimentos.Size = new System.Drawing.Size(320, 196);
            this.listBoxAtendimentos.TabIndex = 8;
            this.btnListarAtendimentos.Location = new System.Drawing.Point(396, 247);
            this.btnListarAtendimentos.Name = "btnListarAtendimentos";
            this.btnListarAtendimentos.Size = new System.Drawing.Size(320, 30);
            this.btnListarAtendimentos.TabIndex = 10;
            this.btnListarAtendimentos.Text = "Listar Atendimentos";
            this.btnListarAtendimentos.UseVisualStyleBackColor = true;
            this.btnListarAtendimentos.Click += new System.EventHandler(this.btnListarAtendimentos_Click);
            this.labelGuiche.AutoSize = true;
            this.labelGuiche.Location = new System.Drawing.Point(396, 20);
            this.labelGuiche.Name = "labelGuiche";
            this.labelGuiche.Size = new System.Drawing.Size(49, 16);
            this.labelGuiche.TabIndex = 9;
            this.labelGuiche.Text = "Guiche";
            this.ClientSize = new System.Drawing.Size(734, 301);
            this.Controls.Add(this.btnListarAtendimentos);
            this.Controls.Add(this.listBoxAtendimentos);
            this.Controls.Add(this.btnChamar);
            this.Controls.Add(this.labelGuiche);
            this.Controls.Add(this.numericUpDownGuiche);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnListarSenhas);
            this.Controls.Add(this.listBoxSenhas);
            this.Controls.Add(this.btnGerar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGuiche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

