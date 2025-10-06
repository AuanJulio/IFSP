using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBiblioteca
{
    internal class Exemplar
    {

        private int tombo;
        private List<Emprestimo> emprestimos;

        public int Tombo { get => tombo; }

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
            emprestimos = new List<Emprestimo>();
        }

        public bool Disponivel()
        {
            if (emprestimos.Count == 0) return true;
            return emprestimos[emprestimos.Count - 1].EstaDevolvido();
        }

        public bool Emprestar()
        {
            if (Disponivel())
            {
                emprestimos.Add(new Emprestimo());
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            if (!Disponivel())
            {
                emprestimos[emprestimos.Count - 1].RegistrarDevolucao();
                return true;
            }
            return false;
        }

        public int QtdeEmprestimos()
        {
            return emprestimos.Count;
        }

        public override string ToString()
        {
            string texto = $"Tombo: {tombo}, Disponível: {(Disponivel() ? "Sim" : "Não")}, Empréstimos: {QtdeEmprestimos()}\n";
            foreach (var e in emprestimos)
                texto += "   - " + e.ToString() + "\n";
            return texto;
        }

    }
}
