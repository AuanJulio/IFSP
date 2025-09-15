using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    internal class Pedidos
    {

        private Pedido[] pedidos;
        private int qtde;
        private const int MAX_PEDIDOS = 100;

        public int Qtde { get => qtde; }

        public Pedidos()
        {
            this.qtde = 0;
            this.pedidos = new Pedido[MAX_PEDIDOS];
            for (int i = 0; i < MAX_PEDIDOS; i++)
                this.pedidos[i] = new Pedido();
        }

        public bool adicionar(Pedido p)
        {
            if (qtde < MAX_PEDIDOS)
            {
                pedidos[qtde++] = p;
                return true;
            }
            return false;
        }

        public Pedido pesquisar(Pedido p)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (pedidos[i].Equals(p))
                    return pedidos[i];
            }
            return new Pedido();
        }

        public bool remover(Pedido p)
        {
            int i = 0;
            while (i < qtde && !pedidos[i].Equals(p)) i++;
            if (i < qtde)
            {
                for (int j = i; j < qtde - 1; j++)
                    pedidos[j] = pedidos[j + 1];
                pedidos[qtde - 1] = new Pedido();
                qtde--;
                return true;
            }
            return false;
        }

        public string mostrar()
        {
            string ret = "";
            double soma = 0.0;
            for (int i = 0; i < qtde; i++)
            {
                ret += pedidos[i].ToString();
                soma += pedidos[i].calcularTotal();
            }
            ret += $"Soma Geral do Dia: R$ {soma:F2}\n";
            return ret;
        }

    }
}
