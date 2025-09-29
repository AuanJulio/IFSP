namespace ListasAgendaWFA
{
    public partial class Form1 : Form
    {
        private Contatos listaContatos;
        BindingSource bs;

        public Form1()
        {
            InitializeComponent();
            listaContatos = new Contatos();
            bs = new BindingSource();
            atualizaLista();
        }

        private void atualizaLista()
        {
            bs = new BindingSource();
            bs.DataSource = listaContatos.Agenda;
            dataGridView1.DataSource = bs;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txId.Text);
            DateTime selectedDate = dateTimePicker1.Value;
            Contato novo = new Contato(id, txEmail.Text, txNome.Text,
                    new Data(selectedDate.Day, selectedDate.Month, selectedDate.Year),
                    new List<Telefone>());

            novo.adicionarTelefone(new Telefone(txTipoTelefone.Text, txNumeroTelefone.Text, true));

            MessageBox.Show(listaContatos.adicionar(novo) ? "Contato adicionado!" : "Contato já existe!");
            atualizaLista();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (bs.Position < 0)
            {
                MessageBox.Show("Nenhum contato selecionado.");
                return;
            }
            Contato selecionado = listaContatos.Agenda[bs.Position];
            Contato contatoExistente = listaContatos.pesquisar(new Contato(selecionado.Id));

            if (contatoExistente.Id == -1)
            {
                MessageBox.Show("Contato não encontrado.");
                return;
            }
            DateTime selectedDateTime = dateTimePicker1.Value;

            contatoExistente.Nome = txNome.Text;
            contatoExistente.Email = txEmail.Text;
            contatoExistente.DtNasc = new Data(selectedDateTime.Day, selectedDateTime.Month, selectedDateTime.Year);

            DialogResult result = MessageBox.Show("Deseja adicionar um novo telefone? (S/N)", "Alterar contato", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    contatoExistente.adicionarTelefone(new Telefone(txTipoTelefone.Text, txNumeroTelefone.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao adicionar telefone: {ex.Message}");
                }
            }
            listaContatos.alterar(contatoExistente);
            atualizaLista();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (bs.Position >= 0)
            {
                Contato selecionado = listaContatos.Agenda[bs.Position];

                if (listaContatos.remover(selecionado))
                {
                    MessageBox.Show("Contato removido com sucesso!");
                    atualizaLista();
                }
                else
                {
                    MessageBox.Show("Erro ao remover contato.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um contato para remover.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(this.listaContatos.Agenda[bs.Position].ToString());
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (bs.Current is Contato c)
            {
                txId.Text = c.Id.ToString();
                txNome.Text = c.Nome;
                txEmail.Text = c.Email;
                dateTimePicker1.Value = new DateTime(c.DtNasc.Ano, c.DtNasc.Mes, c.DtNasc.Dia);

                if (c.Telefones.Any())
                {
                    var tel = c.Telefones.Last();
                    txTipoTelefone.Text = tel.Tipo;
                    txNumeroTelefone.Text = tel.Numero;
                }
            }
        }
    }
}
