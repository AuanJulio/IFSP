using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMedicamentos
{
    internal class Lote
    {

        private int id;
        private int qtde;
        private DateTime venc;

        public int Id { get => id; set => id = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        public DateTime Venc { get => venc; set => venc = value; }

        public Lote()
        {
            this.id = -1;
            this.qtde = 0;
            this.venc = DateTime.Now;
        }

        public Lote(int id, int qtde, DateTime venc)
        {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }

        public override string ToString()
        {
            return $"{id} - {qtde} - {venc:dd/MM/yyyy}";
        }

    }
}
