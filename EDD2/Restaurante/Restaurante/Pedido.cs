using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    internal class Pedido
    {

        private int id;
        private string cliente;
        private Item[] itens;
        private int qtde;

        private const int MAX_ITENS = 20;

        public int Id { get => id; set => id = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public int Qtde { get => qtde; }

        public Pedido(int id, string cliente)
        {
            this.id = id;
            this.cliente = cliente;
            this.qtde = 0;
            this.itens = new Item[MAX_ITENS];
            for (int i = 0; i < MAX_ITENS; i++)
                this.itens[i] = new Item();
        }

        public Pedido(int id) : this(id, "") { }
        public Pedido() : this(-1, "") { }

        public bool adicionarItem(Item item)
        {
            if (qtde < MAX_ITENS)
            {
                itens[qtde++] = item;
                return true;
            }
            return false;
        }

        public bool removerItem(Item item)
        {
            int i = 0;
            while (i < qtde && !itens[i].Equals(item)) i++;
            if (i < qtde)
            {
                for (int j = i; j < qtde - 1; j++)
                    itens[j] = itens[j + 1];
                itens[qtde - 1] = new Item();
                qtde--;
                return true;
            }
            return false;
        }

        public double calcularTotal()
        {
            double total = 0.0;
            for (int i = 0; i < qtde; i++)
                total += itens[i].Preco;
            return total;
        }

        public string mostrarItens()
        {
            string ret = "";
            for (int i = 0; i < qtde; i++)
                ret += itens[i].ToString();
            return ret;
        }

        public override string ToString()
        {
            return $"Pedido {id} - Cliente: {cliente} - Total: R$ {calcularTotal():F2}\n";
        }

        public override bool Equals(object obj)
        {
            return (this.Id == ((Pedido)obj).Id);
        }

    }
}
