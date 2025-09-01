using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendedores
{
    internal class Vendedores
    {

        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
        }

        public bool addVendedor(Vendedor v)
        {
            if (qtde >= max) return false;
            osVendedores[qtde++] = v;
            return true;
        }

        public bool delVendedor(int id)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Id == id)
                {
                    if (osVendedores[i].temVendas()) return false; // não pode excluir
                    for (int j = i; j < qtde - 1; j++)
                        osVendedores[j] = osVendedores[j + 1];
                    osVendedores[--qtde] = null;
                    return true;
                }
            }
            return false;
        }

        public Vendedor searchVendedor(int id)
        {
            for (int i = 0; i < qtde; i++)
                if (osVendedores[i].Id == id) return osVendedores[i];
            return null;
        }

        public double valorVendas()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
                total += osVendedores[i].valorVendas();
            return total;
        }

        public double valorComissao()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
                total += osVendedores[i].valorComissao();
            return total;
        }

        public string listar()
        {
            string ret = "";
            for (int i = 0; i < qtde; i++)
                ret += osVendedores[i].ToString() + "\n";

            ret += $"TOTAL VENDAS: {valorVendas():C} | TOTAL COMISSÕES: {valorComissao():C}";
            return ret;
        }

    }
}
