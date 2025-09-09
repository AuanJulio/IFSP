using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos
{
    internal class Disciplina
    {
        private int id;
        private string descricao;
        private Aluno[] alunos;
        private int qtde;

        private const int MAX_ALUNOS = 15;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int Qtde { get => qtde; }

        public Disciplina(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.qtde = 0;
            this.alunos = new Aluno[MAX_ALUNOS];
            for (int i = 0; i < MAX_ALUNOS; ++i)
                this.alunos[i] = new Aluno();
        }

        public Disciplina(int id) : this(id, "")
        {
        }

        public Disciplina() : this(-1, "")
        {
        }

        public bool matricularAluno(Aluno aluno)
        {
            if (qtde < MAX_ALUNOS)
            {
                alunos[qtde++] = aluno;
                return true;
            }
            return false;
        }

        public bool desmatricularAluno(Aluno aluno)
        {
            int i = 0;
            while (i < qtde && !alunos[i].Equals(aluno)) i++;
            if (i < qtde)
            {
                for (int j = i; j < qtde - 1; ++j)
                    alunos[j] = alunos[j + 1];
                alunos[qtde - 1] = new Aluno();
                qtde--;
                return true;
            }
            return false;
        }

        public string mostrarAlunos()
        {
            string ret = "";
            for (int i = 0; i < qtde; i++)
                ret += alunos[i].ToString();
            return ret;
        }

        public override string ToString()
        {
            return this.id + " - " + this.descricao + '\n';
        }

        public override bool Equals(object obj)
        {
            return (this.Id == ((Disciplina)obj).Id);
        }

    }
}
