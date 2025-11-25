using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessos
{
    internal class AmbienteDAL
    {

        private string connStr = "Server=localhost;Database=projacessosdb;User Id=root;Password=admin;";

        public void insert(Ambiente a)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Ambientes(id, nome) VALUES (@id, @nome)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", a.Id);
                cmd.Parameters.AddWithValue("@nome", a.Nome);
                cmd.ExecuteNonQuery();
            }
        }

        public void delete(Ambiente a)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM Ambientes WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", a.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public Ambiente select(int id)
        {
            Ambiente a = null;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Ambientes WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    a = new Ambiente((int)rd["id"], (string)rd["nome"]);
                }
            }

            return a;
        }

        public List<Ambiente> selectAll()
        {
            List<Ambiente> lista = new List<Ambiente>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Ambientes";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lista.Add(new Ambiente((int)rd["id"], (string)rd["nome"]));
                }
            }

            return lista;
        }

    }
}
