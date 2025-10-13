using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGerenciamentoProjetos
{
    internal class Projeto
    {

        private int id;
        private string nome;
        private List<Tarefa> tarefas;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public List<Tarefa> Tarefas { get => tarefas; }

        public Projeto(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            this.tarefas = new List<Tarefa>();
        }

        public Projeto(int id) : this(id, "")
        {
        }

        public Projeto() : this(-1, "")
        {
        }

        public bool adicionarTarefa(Tarefa t)
        {
            if (tarefas.Count >= 50) return false;
            tarefas.Add(t);
            return true;
        }

        public bool removerTarefa(Tarefa t)
        {
            return tarefas.Remove(t);
        }

        public Tarefa buscarTarefa(Tarefa t)
        {
            foreach (Tarefa tar in tarefas)
            {
                if (tar.Equals(t))
                    return tar;
            }
            return new Tarefa();
        }

        public List<Tarefa> tarefasPorStatus(string s)
        {
            List<Tarefa> filtradas = new List<Tarefa>();
            foreach (Tarefa tar in tarefas)
            {
                if (tar.Status.Equals(s, StringComparison.OrdinalIgnoreCase))
                    filtradas.Add(tar);
            }
            return filtradas;
        }

        public List<Tarefa> tarefasPorPrioridade(int p)
        {
            List<Tarefa> filtradas = new List<Tarefa>();
            foreach (Tarefa tar in tarefas)
            {
                if (tar.Prioridade == p)
                    filtradas.Add(tar);
            }
            return filtradas;
        }

        public int totalAbertas()
        {
            int cont = 0;
            foreach (Tarefa t in tarefas)
            {
                if (t.Status == "Aberta") cont++;
            }
            return cont;
        }

        public int totalFechadas()
        {
            int cont = 0;
            foreach (Tarefa t in tarefas)
            {
                if (t.Status == "Fechada") cont++;
            }
            return cont;
        }

        public int totalCanceladas()
        {
            int cont = 0;
            foreach (Tarefa t in tarefas)
            {
                if (t.Status == "Cancelada") cont++;
            }
            return cont;
        }

        public override string ToString()
        {
            return $"Projeto {id} - {nome} | Tarefas: {tarefas.Count}";
        }

        public override bool Equals(object obj)
        {
            return (this.id == ((Projeto)obj).id);
        }

    }
}
