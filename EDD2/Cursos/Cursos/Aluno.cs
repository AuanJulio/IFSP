using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos
{
    internal class Aluno
    {
        private int id;
        private string nome;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }

        public Aluno(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public Aluno(int id) : this(id, "")
        {
        }

        public Aluno() : this(-1, "")
        {
        }

        public override string ToString()
        {
            return this.id.ToString() + " - " + this.nome + '\n';
        }

        public override bool Equals(object obj)
        {
            return (this.Id == ((Aluno)obj).Id);
        }

    }
}
