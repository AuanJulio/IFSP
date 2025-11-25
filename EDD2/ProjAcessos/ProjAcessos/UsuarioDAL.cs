using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessos
{
    internal class UsuarioDAL
    {

        private string connStr = "Server=localhost;Database=projacessosdb;User Id=root;Password=admin;";

        public void insert(Usuario u)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Usuarios(id, nome) VALUES (@id, @nome)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", u.Id);
                cmd.Parameters.AddWithValue("@nome", u.Nome);
                cmd.ExecuteNonQuery();
            }
        }

        public void delete(Usuario u)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM Usuarios WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", u.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public Usuario select(int id)
        {
            Usuario u = null;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Usuarios WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    u = new Usuario((int)rd["id"], (string)rd["nome"]);
                }
            }

            return u;
        }

        public List<Usuario> selectAll()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Usuarios";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lista.Add(new Usuario((int)rd["id"], (string)rd["nome"]));
                }
            }

            return lista;
        }

    }
}
