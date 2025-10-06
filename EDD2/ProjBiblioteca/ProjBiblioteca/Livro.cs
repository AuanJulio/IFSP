using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBiblioteca
{
    internal class Livro
    {

        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public int Isbn { get => isbn; }
        public string Titulo { get => titulo; }
        public string Autor { get => autor; }
        public string Editora { get => editora; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            exemplares = new List<Exemplar>();
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            int cont = 0;
            foreach (var ex in exemplares)
                if (ex.Disponivel()) cont++;
            return cont;
        }

        public int QtdeEmprestimos()
        {
            int total = 0;
            foreach (var ex in exemplares)
                total += ex.QtdeEmprestimos();
            return total;
        }

        public double PercDisponibilidade()
        {
            if (QtdeExemplares() == 0) return 0;
            return (QtdeDisponiveis() * 100.0) / QtdeExemplares();
        }

        public override bool Equals(object obj)
        {
            return obj is Livro livro && this.isbn == livro.isbn;
        }

        public override string ToString()
        {
            return $"ISBN: {isbn}, Título: {titulo}, Autor: {autor}, Editora: {editora}";
        }

        public string Analitico()
        {
            string texto = ToString() + "\n";
            texto += $"Total exemplares: {QtdeExemplares()}, Disponíveis: {QtdeDisponiveis()}, Empréstimos: {QtdeEmprestimos()}, Disponibilidade: {PercDisponibilidade():F2}%\n";
            foreach (var ex in exemplares)
                texto += ex.ToString();
            return texto;
        }

        public Exemplar BuscarExemplar(int tombo)
        {
            foreach (var ex in exemplares)
                if (ex.Tombo == tombo) return ex;
            return null;
        }

    }
}
