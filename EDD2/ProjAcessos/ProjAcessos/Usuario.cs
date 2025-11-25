using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessos
{
    internal class Usuario
    {

        private int id;
        private string nome;
        private List<Ambiente> ambientes;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public List<Ambiente> Ambientes { get => ambientes; set => ambientes = value; }

        public Usuario()
        {
            ambientes = new List<Ambiente>();
        }

        public Usuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            ambientes = new List<Ambiente>();
        }

        public bool concederPermissao(Ambiente ambiente)
        {
            if (ambientes.Contains(ambiente))
                return false;

            ambientes.Add(ambiente);
            return true;
        }

        public bool revogarPermissao(Ambiente ambiente)
        {
            return ambientes.Remove(ambiente);
        }

        public override string ToString()
        {
            return $"{id} - {nome}";
        }

    }
}
