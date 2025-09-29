using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasAgendaWFA
{
    internal class Data
    {

        private int dia;
        private int mes;
        private int ano;

        public int Dia { get => dia; set => dia = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Ano { get => ano; set => ano = value; }

        public Data(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }
        public Data(int dia, int mes) : this(dia, mes, 2000) { }
        public Data() : this(1, 1, 2000) { }

        public void setData(int d, int m, int a)
        {
            dia = d;
            mes = m;
            ano = a;
        }

        public override string ToString()
        {
            return $"{dia:D2}/{mes:D2}/{ano:D4}";
        }

    }
}
