using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessos
{
    internal class Ambiente
    {

        private int id;
        private string nome;
        private Queue<Log> logs;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public Queue<Log> Logs { get => logs; set => logs = value; }

        public Ambiente()
        {
            logs = new Queue<Log>();
        }

        public Ambiente(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            logs = new Queue<Log>();
        }

        public void registrarLog(Log log)
        {
            if (logs.Count >= 100)
                logs.Dequeue();

            logs.Enqueue(log);
        }

        public override string ToString()
        {
            return $"{id} - {nome}";
        }

    }
}
