using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos
{
    internal class Curso
    {

        private int id;
        private string descricao;
        private Disciplina[] disciplinas;
        private int qtde;

        private const int MAX_DISCIPLINAS = 12;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int Qtde { get => qtde; }

        public Curso(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.qtde = 0;
            this.disciplinas = new Disciplina[MAX_DISCIPLINAS];
            for (int i = 0; i < MAX_DISCIPLINAS; ++i)
                this.disciplinas[i] = new Disciplina();
        }

        public Curso(int id) : this(id, "")
        {
        }

        public Curso() : this(-1, "")
        {
        }

        public bool adicionarDisciplina(Disciplina d)
        {
            if (qtde < MAX_DISCIPLINAS)
            {
                disciplinas[qtde++] = d;
                return true;
            }
            return false;
        }

        public Disciplina pesquisarDisciplina(Disciplina d)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (disciplinas[i].Equals(d))
                    return disciplinas[i];
            }
            return new Disciplina();
        }

        public bool removerDisciplina(Disciplina d)
        {
            int i = 0;
            while (i < qtde && !disciplinas[i].Equals(d)) i++;
            if (i < qtde)
            {
                for (int j = i; j < qtde - 1; ++j)
                    disciplinas[j] = disciplinas[j + 1];
                disciplinas[qtde - 1] = new Disciplina();
                qtde--;
                return true;
            }
            return false;
        }

        public string mostrarDisciplinas()
        {
            string ret = "";
            for (int i = 0; i < qtde; i++)
                ret += disciplinas[i].ToString();
            return ret;
        }

        public override string ToString()
        {
            return this.id + " - " + this.descricao + '\n';
        }

        public override bool Equals(object obj)
        {
            return (this.Id == ((Curso)obj).Id);
        }

    }
}
