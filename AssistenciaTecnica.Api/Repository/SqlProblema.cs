using MySql.Data.MySqlClient;

namespace Api4
{
    public class SqlProblema
    {
        private readonly Conexao _connection;

        public SqlProblema(Conexao conexao)
        {
            _connection = conexao;
        }

        public List<OrdemDeServiço> Listar(int idcliente)
        {
            try
            {
                List<OrdemDeServiço> serviços = new List<OrdemDeServiço> ();
                using (MySqlConnection conn = _connection.GetConnection())
                {
                    conn.Open();
                    string listar = "SELECT api4problema.id, api4.Nome, api4problema.idcliente, aparelho, descrição, dia, stats, valor FROM api4problema JOIN api4 ON api4.Id = api4problema.idcliente WHERE idcliente = @id";
                    MySqlCommand cmd = new MySqlCommand(listar, conn);
                    cmd.Parameters.AddWithValue ("id", idcliente);
                    
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string cliente = reader.GetString("nome");
                        int idCliente = reader.GetInt32("idcliente");
                        string aparelho = reader.GetString("aparelho");
                        string descrição = reader.GetString("descrição");
                        DateTime data = reader.GetDateTime("dia");
                        string status = reader.GetString("stats");
                        decimal valor = reader.GetDecimal("valor");
                        DateOnly dia = DateOnly.FromDateTime(data);
                        serviços.Add(new OrdemDeServiço(id, cliente, idCliente, aparelho, descrição, dia, status, valor));
                    }
                    return serviços;
                }
            }
            catch
            {
                throw;
            }
        }

        public void Adicionar(OrdemDeServiço ordem)
        {
            try
            {
                DateTime data = ordem.Data.ToDateTime(TimeOnly.MinValue);
                using(MySqlConnection conn = _connection.GetConnection())
                {
                    conn.Open();
                    string adicionar = "INSERT INTO api4problema(idcliente, aparelho, descrição, dia, stats, valor) VALUES (@idcliente, @aparelho, @descrição, @dia, @status, @valor)";
                    MySqlCommand cmd = new MySqlCommand(adicionar, conn);
                    cmd.Parameters.AddWithValue("@idcliente", ordem.IdCliente);
                    cmd.Parameters.AddWithValue("@aparelho", ordem.Aparelho);
                    cmd.Parameters.AddWithValue("@descrição", ordem.Descrição);
                    cmd.Parameters.AddWithValue("@dia", data);
                    cmd.Parameters.AddWithValue("@status", ordem.Status);
                    cmd.Parameters.AddWithValue("@valor", ordem.Valor);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }


    }
}
