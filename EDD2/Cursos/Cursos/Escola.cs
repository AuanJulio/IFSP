using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos
{
    internal class Escola
    {

        private Curso[] cursos;
        private int qtde;

        private const int MAX_CURSOS = 5;

        public int Qtde { get => qtde; }

        public Escola()
        {
            this.qtde = 0;
            this.cursos = new Curso[MAX_CURSOS];
            for (int i = 0; i < MAX_CURSOS; ++i)
                this.cursos[i] = new Curso();
        }

        public bool adicionarCurso(Curso c)
        {
            if (qtde < MAX_CURSOS)
            {
                cursos[qtde++] = c;
                return true;
            }
            return false;
        }

        public Curso pesquisarCurso(Curso c)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (cursos[i].Equals(c))
                    return cursos[i];
            }
            return new Curso();
        }

        public bool removerCurso(Curso c)
        {
            int i = 0;
            while (i < qtde && !cursos[i].Equals(c)) i++;
            if (i < qtde)
            {
                for (int j = i; j < qtde - 1; ++j)
                    cursos[j] = cursos[j + 1];
                cursos[qtde - 1] = new Curso();
                qtde--;
                return true;
            }
            return false;
        }

        public string mostrarCursos()
        {
            string ret = "";
            for (int i = 0; i < qtde; i++)
                ret += cursos[i].ToString();
            return ret;
        }

    }
}
