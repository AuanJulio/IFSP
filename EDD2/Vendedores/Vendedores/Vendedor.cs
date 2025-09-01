using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendedores
{
    internal class Vendedor
    {

        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31]; // vendas por dia
            for (int i = 0; i < 31; i++) asVendas[i] = new Venda();
        }

        public void registrarVenda(int dia, Venda venda)
        {
            if (dia < 1 || dia > 31) return;
            asVendas[dia - 1] = venda;
        }

        public double valorVendas()
        {
            double total = 0;
            foreach (var v in asVendas)
                if (v != null) total += v.Valor;
            return total;
        }

        public double valorComissao()
        {
            return valorVendas() * (percComissao / 100);
        }

        public bool temVendas()
        {
            foreach (var v in asVendas)
                if (v != null && v.Qtde > 0) return true;
            return false;
        }

        public override string ToString()
        {
            return $"{id} - {nome} | Vendas: {valorVendas():C} | Comissão: {valorComissao():C}";
        }

    }
}
