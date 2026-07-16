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

        public List<OrdemDeServico> Listar(int idcliente)
        {
            try
            {
                List<OrdemDeServico> serviços = new List<OrdemDeServico> ();
                using (MySqlConnection conn = _connection.GetConnection())
                {
                    conn.Open();
                    string listar = "SELECT serviço.Id, cliente.Nome, serviço.IdCliente, Aparelho, Descrição, Dia, Stats, Valor FROM cliente JOIN serviço ON cliente.Id = serviço.IdCliente WHERE IdCliente = @id";
                    MySqlCommand cmd = new MySqlCommand(listar, conn);
                    cmd.Parameters.AddWithValue ("@id", idcliente);
                    
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        string cliente = reader.GetString("Nome");
                        int idCliente = reader.GetInt32("IdCliente");
                        string aparelho = reader.GetString("Aparelho");
                        string descrição = reader.GetString("Descrição");
                        DateTime data = reader.GetDateTime("Dia");
                        string status = reader.GetString("Stats"); 
                        decimal valor = reader.GetDecimal("Valor");
                        DateOnly dia = DateOnly.FromDateTime(data);
                        serviços.Add(new OrdemDeServico(id, cliente, idCliente, aparelho, descrição, dia, status, valor));
                    }
                    return serviços;
                }
            }
            catch
            {
                throw;
            }
        }

        public void Adicionar(OrdemDeServico ordem)
        {
            try
            {
                DateTime data = ordem.Data.ToDateTime(TimeOnly.MinValue);
                using(MySqlConnection conn = _connection.GetConnection())
                {
                    conn.Open();
                    string adicionar = "INSERT INTO serviço(IdCliente, Aparelho, Descrição, Dia, Stats, Valor) VALUES (@idcliente, @aparelho, @descrição, @dia, @status, @valor)";
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
