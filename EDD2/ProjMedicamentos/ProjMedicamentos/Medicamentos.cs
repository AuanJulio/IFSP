using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMedicamentos
{
    internal class Medicamentos
    {

        private List<Medicamento> listaMedicamentos;

        public List<Medicamento> ListaMedicamentos { get => listaMedicamentos; }

        public Medicamentos()
        {
            this.listaMedicamentos = new List<Medicamento>();
        }

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            Medicamento m = Pesquisar(medicamento);
            if (m.Id != -1 && m.QtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(m);
                return true;
            }
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento m in listaMedicamentos)
            {
                if (m.Equals(medicamento))
                    return m;
            }
            return new Medicamento();
        }

        public string ListarSintetico()
        {
            string texto = "";
            foreach (Medicamento m in listaMedicamentos)
            {
                texto += m.ToString() + "\n";
            }
            return texto;
        }

    }
}
