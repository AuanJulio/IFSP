using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessos
{
    internal class Log
    {

        private DateTime dtAcesso;
        private Usuario usuario;
        private bool tipoAcesso;

        public DateTime DtAcesso { get => dtAcesso; set => dtAcesso = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }
        public bool TipoAcesso { get => tipoAcesso; set => tipoAcesso = value; }

        public Log() { }

        public Log(DateTime dtAcesso, Usuario usuario, bool tipoAcesso)
        {
            this.dtAcesso = dtAcesso;
            this.usuario = usuario;
            this.tipoAcesso = tipoAcesso;
        }

        public override string ToString()
        {
            string tipo = tipoAcesso ? "AUTORIZADO" : "NEGADO";
            return $"{dtAcesso} - Usuário {usuario.Id} - {tipo}";
        }

    }
}
