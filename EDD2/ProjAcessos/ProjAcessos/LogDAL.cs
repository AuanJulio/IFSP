using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessos
{
    internal class LogDAL
    {

        private string connStr = "Server=localhost;Database=projacessosdb;User Id=root;Password=admin;";

        public void insertLog(Log log, int idAmbiente, int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "INSERT INTO Logs(id, idAmbiente, idUsuario, dtAcesso, tipoAcesso) VALUES (@id, @idA, @idU, @dt, @tipo)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", gerarId(conn));
                cmd.Parameters.AddWithValue("@idA", idAmbiente);
                cmd.Parameters.AddWithValue("@idU", idUsuario);
                cmd.Parameters.AddWithValue("@dt", log.DtAcesso);
                cmd.Parameters.AddWithValue("@tipo", log.TipoAcesso);
                cmd.ExecuteNonQuery();
            }
        }

        private int gerarId(SqlConnection conn)
        {
            string sql = "SELECT ISNULL(MAX(id), 0) + 1 FROM Logs";
            SqlCommand cmd = new SqlCommand(sql, conn);
            return (int)cmd.ExecuteScalar();
        }

        public void carregarLogs(List<Ambiente> ambientes, List<Usuario> usuarios)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Logs ORDER BY dtAcesso DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    int ambId = (int)rd["idAmbiente"];
                    int userId = (int)rd["idUsuario"];

                    Ambiente ambiente = ambientes.Find(a => a.Id == ambId);
                    Usuario usuario = usuarios.Find(u => u.Id == userId);

                    if (ambiente != null && usuario != null)
                    {
                        Log log = new Log((DateTime)rd["dtAcesso"], usuario, (bool)rd["tipoAcesso"]);
                        ambiente.registrarLog(log);
                    }
                }
            }
        }

    }
}
