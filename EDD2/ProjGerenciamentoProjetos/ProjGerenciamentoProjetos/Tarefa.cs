using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGerenciamentoProjetos
{
    internal class Tarefa
    {

        private int id;
        private string titulo;
        private string descricao;
        private int prioridade;
        private string status;
        private DateTime dataCriacao;
        private DateTime dataConclusao;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int Prioridade { get => prioridade; set => prioridade = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public DateTime DataConclusao { get => dataConclusao; set => dataConclusao = value; }

        public Tarefa(int id, string titulo, string descricao, int prioridade)
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.prioridade = prioridade;
            this.status = "Aberta";
            this.dataCriacao = DateTime.Now;
            this.dataConclusao = DateTime.MinValue;
        }

        public Tarefa(int id) : this(id, "", "", 3)
        {
        }

        public Tarefa() : this(-1, "", "", 3)
        {
        }

        public void concluir()
        {
            if (status == "Aberta")
            {
                status = "Fechada";
                dataConclusao = DateTime.Now;
            }
        }

        public void cancelar()
        {
            if (status != "Cancelada")
            {
                status = "Cancelada";
                dataConclusao = DateTime.Now;
            }
        }

        public void reabrir()
        {
            if (status != "Aberta")
            {
                status = "Aberta";
                dataConclusao = DateTime.MinValue;
            }
        }

        public override string ToString()
        {
            string pri = prioridade == 1 ? "Alta" : prioridade == 2 ? "Média" : "Baixa";
            return $"{id} - {titulo} ({descricao}) | Prioridade: {pri} | Status: {status}";
        }

        public override bool Equals(object obj)
        {
            return (this.id == ((Tarefa)obj).id);
        }

    }
}
