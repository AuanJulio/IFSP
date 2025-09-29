namespace ListasAgendaWFA
{
    partial class Form1
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
            btnAdicionar = new Button();
            btnRemover = new Button();
            btnAlterar = new Button();
            lbId = new Label();
            lbEmail = new Label();
            lbNome = new Label();
            lbTipoTelefone = new Label();
            lbNumeroTelefone = new Label();
            dataGridView1 = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            txId = new TextBox();
            txEmail = new TextBox();
            txNome = new TextBox();
            txTipoTelefone = new TextBox();
            txNumeroTelefone = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(14, 16);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(142, 29);
            btnAdicionar.TabIndex = 0;
            btnAdicionar.Text = "Adicionar contato";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(14, 51);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(142, 29);
            btnRemover.TabIndex = 1;
            btnRemover.Text = "Remover contato";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(14, 86);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(142, 29);
            btnAlterar.TabIndex = 2;
            btnAlterar.Text = "Alterar contato";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(347, 25);
            lbId.Name = "lbId";
            lbId.Size = new Size(27, 20);
            lbId.TabIndex = 3;
            lbId.Text = "ID:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(319, 60);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(55, 20);
            lbEmail.TabIndex = 4;
            lbEmail.Text = "E-mail:";
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(321, 95);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(53, 20);
            lbNome.TabIndex = 5;
            lbNome.Text = "Nome:";
            // 
            // lbTipoTelefone
            // 
            lbTipoTelefone.AutoSize = true;
            lbTipoTelefone.Location = new Point(271, 134);
            lbTipoTelefone.Name = "lbTipoTelefone";
            lbTipoTelefone.Size = new Size(103, 20);
            lbTipoTelefone.TabIndex = 6;
            lbTipoTelefone.Text = "Tipo Telefone:";
            // 
            // lbNumeroTelefone
            // 
            lbNumeroTelefone.AutoSize = true;
            lbNumeroTelefone.Location = new Point(247, 167);
            lbNumeroTelefone.Name = "lbNumeroTelefone";
            lbNumeroTelefone.Size = new Size(127, 20);
            lbNumeroTelefone.TabIndex = 7;
            lbNumeroTelefone.Text = "Número Telefone:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 284);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(774, 226);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(347, 211);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(138, 27);
            dateTimePicker1.TabIndex = 9;
            // 
            // txId
            // 
            txId.Location = new Point(380, 18);
            txId.Name = "txId";
            txId.Size = new Size(125, 27);
            txId.TabIndex = 10;
            // 
            // txEmail
            // 
            txEmail.AcceptsReturn = true;
            txEmail.Location = new Point(380, 57);
            txEmail.Name = "txEmail";
            txEmail.Size = new Size(125, 27);
            txEmail.TabIndex = 11;
            // 
            // txNome
            // 
            txNome.AcceptsReturn = true;
            txNome.Location = new Point(380, 92);
            txNome.Name = "txNome";
            txNome.Size = new Size(125, 27);
            txNome.TabIndex = 12;
            // 
            // txTipoTelefone
            // 
            txTipoTelefone.AcceptsReturn = true;
            txTipoTelefone.Location = new Point(380, 131);
            txTipoTelefone.Name = "txTipoTelefone";
            txTipoTelefone.Size = new Size(125, 27);
            txTipoTelefone.TabIndex = 13;
            // 
            // txNumeroTelefone
            // 
            txNumeroTelefone.AcceptsReturn = true;
            txNumeroTelefone.Location = new Point(380, 164);
            txNumeroTelefone.Name = "txNumeroTelefone";
            txNumeroTelefone.Size = new Size(125, 27);
            txNumeroTelefone.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 531);
            Controls.Add(txNumeroTelefone);
            Controls.Add(txTipoTelefone);
            Controls.Add(txNome);
            Controls.Add(txEmail);
            Controls.Add(txId);
            Controls.Add(dateTimePicker1);
            Controls.Add(dataGridView1);
            Controls.Add(lbNumeroTelefone);
            Controls.Add(lbTipoTelefone);
            Controls.Add(lbNome);
            Controls.Add(lbEmail);
            Controls.Add(lbId);
            Controls.Add(btnAlterar);
            Controls.Add(btnRemover);
            Controls.Add(btnAdicionar);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdicionar;
        private Button btnRemover;
        private Button btnAlterar;
        private Label lbId;
        private Label lbEmail;
        private Label lbNome;
        private Label lbTipoTelefone;
        private Label lbNumeroTelefone;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private TextBox txId;
        private TextBox txEmail;
        private TextBox txNome;
        private TextBox txTipoTelefone;
        private TextBox txNumeroTelefone;
    }
}
