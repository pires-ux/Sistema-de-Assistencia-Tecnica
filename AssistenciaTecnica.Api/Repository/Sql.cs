using MySql.Data.MySqlClient;

namespace Api4
{
    public class Sql
    {
        private readonly Conexao _conexao;

        public Sql(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cliente> Listar()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                using (MySqlConnection conexao = _conexao.GetConnection())
                {
                    conexao.Open();
                    string cmd = "SELECT * FROM cliente";
                    MySqlCommand comando = new MySqlCommand(cmd, conexao);
                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        string nome = reader.GetString("Nome");
                        string telefone = reader.GetString("Telefone");
                        string cpf = reader.GetString("Cpf");
                        string endereco = reader.GetString("Endereço");
                        clientes.Add(new Cliente(id, nome, telefone, cpf, endereco));
                    }
                    return clientes;
                }
            }
            catch
            {
                throw;
            }
            
        }

        public Cliente ObterPorId(int id)
        {
            try
            {
                using (MySqlConnection conexao = _conexao.GetConnection())
                {
                    conexao.Open();
                    string cmd = "SELECT * FROM cliente WHERE Id = @id";
                    MySqlCommand comando = new MySqlCommand(cmd, conexao);
                    comando.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        string nome = reader.GetString("Nome");
                        string telefone = reader.GetString("Telefone");
                        string cpf = reader.GetString("Cpf");
                        string endereco = reader.GetString("Endereço");
                        return new Cliente(id, nome, telefone, cpf, endereco);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Criar(Cliente cliente)
        {
            try
            {
                using(MySqlConnection conexao = _conexao.GetConnection())
                {
                    conexao.Open();
                    string cmd = "INSERT INTO cliente (Nome, Telefone, Cpf, Endereço) VALUES (@nome, @telefone, @cpf, @endereco)";
                    MySqlCommand comando = new MySqlCommand(cmd, conexao);                    
                    comando.Parameters.AddWithValue("@nome", cliente.Nome);
                    comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    comando.ExecuteNonQuery();

                }
            }
            catch
            {
                throw;
            }
        }


    }
}
