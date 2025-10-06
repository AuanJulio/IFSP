using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBiblioteca
{
    internal class Livros
    {

        private List<Livro> acervo;

        public Livros()
        {
            acervo = new List<Livro>();
        }

        public void Adicionar(Livro livro)
        {
            acervo.Add(livro);
        }

        public Livro Pesquisar(Livro livro)
        {
            int index = acervo.IndexOf(livro);
            if (index >= 0)
                return acervo[index];
            return null;
        }

    }
}
