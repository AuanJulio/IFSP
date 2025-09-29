using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasAgendaWFA
{
    internal class Contatos
    {

        private List<Contato> agenda;

        public List<Contato> Agenda { get => agenda; }

        public Contatos()
        {
            agenda = new List<Contato>();
        }

        public bool adicionar(Contato c)
        {
            if (agenda.Contains(c)) return false;
            agenda.Add(c);
            return true;
        }

        public Contato pesquisar(Contato c)
        {
            return agenda.FirstOrDefault(x => x.Equals(c));
        }

        public bool alterar(Contato c)
        {
            int pos = agenda.FindIndex(x => x.Equals(c));
            if (pos >= 0)
            {
                agenda[pos] = c;
                return true;
            }
            return false;
        }

        public bool remover(Contato c)
        {
            return agenda.Remove(c);
        }

    }
}
