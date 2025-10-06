using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBiblioteca
{
    internal class Emprestimo
    {

        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        public DateTime DtEmprestimo
        {
            get => dtEmprestimo;
            set => dtEmprestimo = value;
        }

        public DateTime DtDevolucao
        {
            get => dtDevolucao;
            set => dtDevolucao = value;
        }

        public Emprestimo()
        {
            dtEmprestimo = DateTime.Now;
            dtDevolucao = DateTime.MinValue;
        }

        public void RegistrarDevolucao()
        {
            dtDevolucao = DateTime.Now;
        }

        public bool EstaDevolvido()
        {
            return dtDevolucao != DateTime.MinValue;
        }

        public override string ToString()
        {
            string devolucao = EstaDevolvido() ? dtDevolucao.ToString() : "Em aberto";
            return $"Empréstimo: {dtEmprestimo} | Devolução: {devolucao}";
        }

    }
}
