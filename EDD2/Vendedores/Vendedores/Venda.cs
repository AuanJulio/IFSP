using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendedores
{
    internal class Venda
    {

        private int qtde;
        private double valor;

        public int Qtde { get => qtde; set => qtde = value; }
        public double Valor { get => valor; set => valor = value; }

        public Venda(int qtde, double valor)
        {
            this.qtde = qtde;
            this.valor = valor;
        }

        public Venda() : this(0, 0.0) { }

        public double valorMedio()
        {
            if (qtde == 0) return 0;
            return valor / qtde;
        }

        public override string ToString()
        {
            return $"Qtd: {qtde}, Valor: {valor:C}, Valor Médio: {valorMedio():C}";
        }

    }
}
