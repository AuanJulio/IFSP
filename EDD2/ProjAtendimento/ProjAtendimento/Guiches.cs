using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAtendimento
{
    internal class Guiches
    {

        private List<Guiche> listaGuiches;

        public List<Guiche> ListaGuiches { get => listaGuiches; }

        public Guiches()
        {
            listaGuiches = new List<Guiche>();
        }

        public void adicionar(Guiche guiche)
        {
            listaGuiches.Add(guiche);
        }

        public Guiche buscarPorId(int id)
        {
            foreach (var g in listaGuiches)
                if (g.Id == id) return g;
            return null;
        }

        public int quantidade()
        {
            return listaGuiches.Count;
        }

    }
}
