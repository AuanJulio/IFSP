using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMedicamentos
{
    internal class Medicamento
    {

        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Laboratorio { get => laboratorio; set => laboratorio = value; }
        public Queue<Lote> Lotes { get => lotes; }

        public Medicamento()
        {
            this.id = -1;
            this.nome = "";
            this.laboratorio = "";
            this.lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            this.lotes = new Queue<Lote>();
        }

        public int QtdeDisponivel()
        {
            int total = 0;
            foreach (Lote l in lotes)
                total += l.Qtde;
            return total;
        }

        public void Comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            if (QtdeDisponivel() < qtde)
                return false;

            while (qtde > 0 && lotes.Count > 0)
            {
                Lote primeiro = lotes.Peek();
                if (primeiro.Qtde <= qtde)
                {
                    qtde -= primeiro.Qtde;
                    lotes.Dequeue();
                }
                else
                {
                    primeiro.Qtde -= qtde;
                    qtde = 0;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return $"{id} - {nome} - {laboratorio} - {QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            return (this.id == ((Medicamento)obj).id);
        }

    }
}
