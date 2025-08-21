using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Bilheteria
{
    public partial class Form1 : Form
    {

        private const int fileiras = 15;
        private const int colunas = 40;
        private CheckBox[,] assentos = new CheckBox[fileiras, colunas];
        private bool[,] ocupados = new bool[fileiras, colunas];
        private Label lbFaturamento;
        private bool carregandoAssentos = false;

        public Form1()
        {
            InitializeComponent();
            InitializeMyComponents();
            PreReservarAssentosAleatoriamente();
        }

        private void InitializeMyComponents()
        {
            this.Text = "Sistema de Bilheteria";
            this.WindowState = FormWindowState.Maximized;
            this.AutoScroll = true;

            int inicioX = 30;
            int inicioY = 30;
            int espacamento = 22;

            for (int i = 0; i < fileiras; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Width = 15;
                    cb.Height = 15;
                    cb.Left = inicioX + j * espacamento;
                    cb.Top = inicioY + i * espacamento;
                    cb.Tag = new Point(i, j);
                    cb.CheckedChanged += reservarAssento;
                    assentos[i, j] = cb;
                    this.Controls.Add(cb);
                }
            }

            Button btnFaturamento = new Button();
            btnFaturamento.Text = "Faturamento";
            btnFaturamento.Left = inicioX;
            btnFaturamento.Top = inicioY + fileiras * espacamento + 20;
            btnFaturamento.Click += mostrarFaturamento;
            this.Controls.Add(btnFaturamento);

            lbFaturamento = new Label();
            lbFaturamento.Left = btnFaturamento.Left + 120;
            lbFaturamento.Top = btnFaturamento.Top + 5;
            lbFaturamento.Width = 400;
            this.Controls.Add(lbFaturamento);

            Button btnFinalizar = new Button();
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.Left = inicioX;
            btnFinalizar.Top = btnFaturamento.Top + 40;
            btnFinalizar.Click += (s, e) => Application.Exit();
            this.Controls.Add(btnFinalizar);
        }

        private void reservarAssento(object sender, EventArgs e)
        {
            if (carregandoAssentos) return;

            CheckBox cb = sender as CheckBox;
            if (cb == null) return;

            Point pos = (Point)cb.Tag;
            int linha = pos.X;
            int coluna = pos.Y;

            if (ocupados[linha, coluna])
            {
                MessageBox.Show("Assento já ocupado.");

                carregandoAssentos = true;   
                cb.Checked = true;           
                carregandoAssentos = false;

                return;
            }

            if (cb.Checked)
            {
                ocupados[linha, coluna] = true;
                cb.BackColor = Color.Red;
                cb.ForeColor = Color.White;
            }
        }

        private void mostrarFaturamento(object sender, EventArgs e)
        {
            int ocupadosTotal = 0;
            double valorTotal = 0;

            for (int i = 0; i < fileiras; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    if (ocupados[i, j])
                    {
                        ocupadosTotal++;
                        if (i < 5) valorTotal += 50.0;
                        else if (i < 10) valorTotal += 30.0;
                        else valorTotal += 15.0;
                    }
                }
            }

            lbFaturamento.Text = $"Lugares ocupados: {ocupadosTotal} | Valor: R$ {valorTotal:F2}";
        }

        private void PreReservarAssentosAleatoriamente()
        {
            Random rnd = new Random();
            int reservados = 0;

            carregandoAssentos = true;

            while (reservados < 200)
            {
                int i = rnd.Next(0, fileiras);
                int j = rnd.Next(0, colunas);

                if (!ocupados[i, j])
                {
                    ocupados[i, j] = true;
                    assentos[i, j].Checked = true;
                    assentos[i, j].Enabled = false;
                    assentos[i, j].BackColor = Color.Red;
                    assentos[i, j].ForeColor = Color.White;
                    reservados++;
                }
            }

            carregandoAssentos = false;
        }
    }
}
