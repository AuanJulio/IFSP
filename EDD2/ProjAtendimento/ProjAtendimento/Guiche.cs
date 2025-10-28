using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAtendimento
{
    internal class Guiche
    {

        private int id;
        private Queue<Senha> atendimentos;

        public int Id { get => id; set => id = value; }
        public Queue<Senha> Atendimentos { get => atendimentos; }

        public Guiche()
        {
            this.id = 0;
            this.atendimentos = new Queue<Senha>();
        }

        public Guiche(int id)
        {
            this.id = id;
            this.atendimentos = new Queue<Senha>();
        }

        public bool chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas == null || filaSenhas.Count == 0)
                return false;

            Senha s = filaSenhas.Dequeue();
            s.DataAtend = DateTime.Now.Date;
            s.HoraAtend = DateTime.Now;
            atendimentos.Enqueue(s);
            return true;
        }

    }
}
