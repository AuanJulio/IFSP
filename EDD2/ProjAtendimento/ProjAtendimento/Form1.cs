using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjAtendimento
{
    public partial class Form1 : Form
    {

        private Senhas senhas;
        private Guiches guiches;

        public Form1()
        {
            InitializeComponent();
            senhas = new Senhas();
            guiches = new Guiches();

            AtualizarQtdeGuiches();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            senhas.gerar();
            AtualizarListaSenhas();
        }

        private void btnListarSenhas_Click(object sender, EventArgs e)
        {
            AtualizarListaSenhas();
        }

        private void AtualizarListaSenhas()
        {
            listBoxSenhas.Items.Clear();
            foreach (var s in senhas.FilaSenhas)
                listBoxSenhas.Items.Add(s.dadosParciais());
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int novoId = guiches.quantidade() + 1;
            guiches.adicionar(new Guiche(novoId));
            AtualizarQtdeGuiches();
        }

        private void AtualizarQtdeGuiches()
        {
            lblQtde.Text = guiches.quantidade().ToString();
        }

        private void btnChamar_Click(object sender, EventArgs e)
        {
            if (guiches.quantidade() == 0)
            {
                MessageBox.Show("Não há guichês cadastrados. Adicione um guichê primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int guicheId = (int)numericUpDownGuiche.Value;
            Guiche g = guiches.buscarPorId(guicheId);
            if (g == null)
            {
                MessageBox.Show("Guichê não encontrado. Escolha um guichê válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool ok = g.chamar(senhas.FilaSenhas);
            if (!ok)
            {
                MessageBox.Show("Fila de senhas vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AtualizarListaSenhas();
            AtualizarListaAtendimentos();
        }

        private void btnListarAtendimentos_Click(object sender, EventArgs e)
        {
            AtualizarListaAtendimentos();
        }

        private void AtualizarListaAtendimentos()
        {
            listBoxAtendimentos.Items.Clear();
            foreach (var g in guiches.ListaGuiches)
            {
                foreach (var s in g.Atendimentos)
                {
                    listBoxAtendimentos.Items.Add($"G{g.Id} - {s.dadosCompletos()}");
                }
            }
        }
    }
}
