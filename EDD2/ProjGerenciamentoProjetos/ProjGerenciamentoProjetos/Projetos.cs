using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGerenciamentoProjetos
{
    internal class Projetos
    {

        private List<Projeto> lista;

        public Projetos()
        {
            lista = new List<Projeto>();
        }

        public bool adicionar(Projeto p)
        {
            if (lista.Contains(p))
                return false;
            lista.Add(p);
            return true;
        }

        public bool remover(Projeto p)
        {
            Projeto encontrado = buscar(p);
            if (encontrado.Id != -1 && encontrado.Tarefas.Count == 0)
            {
                lista.Remove(encontrado);
                return true;
            }
            return false;
        }

        public Projeto buscar(Projeto p)
        {
            foreach (Projeto proj in lista)
            {
                if (proj.Equals(p))
                    return proj;
            }
            return new Projeto();
        }

        public List<Projeto> listar()
        {
            return lista;
        }

        public int totalProjetos()
        {
            return lista.Count;
        }

        public int totalTarefasAbertas()
        {
            int total = 0;
            foreach (Projeto p in lista)
            {
                total += p.totalAbertas();
            }
            return total;
        }

        public int totalTarefasFechadas()
        {
            int total = 0;
            foreach (Projeto p in lista)
            {
                total += p.totalFechadas();
            }
            return total;
        }

        public int totalTarefasCanceladas()
        {
            int total = 0;
            foreach (Projeto p in lista)
            {
                total += p.totalCanceladas();
            }
            return total;
        }

    }
}
