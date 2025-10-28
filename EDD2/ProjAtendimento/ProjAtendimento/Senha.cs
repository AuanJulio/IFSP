using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAtendimento
{
    internal class Senha
    {

        private int id;
        private DateTime dataGerac;
        private DateTime horaGerac;
        private DateTime dataAtend;
        private DateTime horaAtend;

        public int Id { get => id; set => id = value; }
        public DateTime DataGerac { get => dataGerac; set => dataGerac = value; }
        public DateTime HoraGerac { get => horaGerac; set => horaGerac = value; }
        public DateTime DataAtend { get => dataAtend; set => dataAtend = value; }
        public DateTime HoraAtend { get => horaAtend; set => horaAtend = value; }

        public Senha(int id)
        {
            this.id = id;
            this.dataGerac = DateTime.Now.Date;
            this.horaGerac = DateTime.Now;
            this.dataAtend = DateTime.MinValue;
            this.horaAtend = DateTime.MinValue;
        }

        public Senha() : this(-1) { }

        public string dadosParciais()
        {
            return $"{id} - {dataGerac:dd/MM/yyyy} - {horaGerac:HH:mm:ss}";
        }

        public string dadosCompletos()
        {
            string atend = (dataAtend == DateTime.MinValue)
                ? " - - - "
                : $" - {dataAtend:dd/MM/yyyy} - {horaAtend:HH:mm:ss}";
            return $"{id} - {dataGerac:dd/MM/yyyy} - {horaGerac:HH:mm:ss}{atend}";
        }

    }
}
