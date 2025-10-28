using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAtendimento
{
    internal class Senhas
    {

        private int proximoAtendimento;
        private Queue<Senha> filaSenhas;

        public int ProximoAtendimento { get => proximoAtendimento; }
        public Queue<Senha> FilaSenhas { get => filaSenhas; }

        public Senhas()
        {
            this.proximoAtendimento = 1;
            this.filaSenhas = new Queue<Senha>();
        }

        public void gerar()
        {
            Senha s = new Senha(proximoAtendimento++);
            filaSenhas.Enqueue(s);
        }

    }
}
