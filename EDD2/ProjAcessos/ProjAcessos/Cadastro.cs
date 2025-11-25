using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessos
{
    internal class Cadastro
    {
        public List<Usuario> usuarios;
        public List<Ambiente> ambientes;

        private UsuarioDAL usuarioDB = new UsuarioDAL();
        private AmbienteDAL ambienteDB = new AmbienteDAL();
        private LogDAL logDB = new LogDAL();

        public Cadastro()
        {
            usuarios = new List<Usuario>();
            ambientes = new List<Ambiente>();
        }

        public void adicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            usuarioDB.insert(usuario);
        }

        public bool removerUsuario(Usuario usuario)
        {
            if (usuario.Ambientes.Count > 0)
                return false;

            usuarios.Remove(usuario);
            usuarioDB.delete(usuario);
            return true;
        }

        public Usuario pesquisarUsuario(int id)
        {
            return usuarioDB.select(id);
        }

        public void adicionarAmbiente(Ambiente ambiente)
        {
            ambientes.Add(ambiente);
            ambienteDB.insert(ambiente);
        }

        public bool removerAmbiente(Ambiente ambiente)
        {
            ambientes.Remove(ambiente);
            ambienteDB.delete(ambiente);
            return true;
        }

        public Ambiente pesquisarAmbiente(int id)
        {
            return ambienteDB.select(id);
        }

        public void registrarAcesso(int idAmbiente, int idUsuario)
        {
            Usuario u = pesquisarUsuario(idUsuario);
            Ambiente a = pesquisarAmbiente(idAmbiente);

            bool autorizado = u.Ambientes.Exists(x => x.Id == idAmbiente);

            Log log = new Log(DateTime.Now, u, autorizado);

            a.registrarLog(log);
            logDB.insertLog(log, idAmbiente, idUsuario);
        }

        public void download()
        {
            usuarios = usuarioDB.selectAll();
            ambientes = ambienteDB.selectAll();
            logDB.carregarLogs(ambientes, usuarios);
        }

    }
}
