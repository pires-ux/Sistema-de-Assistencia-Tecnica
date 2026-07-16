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

        public List<Usuario> Listar()
        {
            try
            {
                List<Usuario> clientes = new List<Usuario>();
                using (MySqlConnection conexao = _conexao.GetConnection())
                {
                    conexao.Open();
                    string cmd = "SELECT * FROM api4";
                    MySqlCommand comando = new MySqlCommand(cmd, conexao);
                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        string nome = reader.GetString("Nome");
                        long telefone = reader.GetInt64("Telefone");
                        long cpf = reader.GetInt64("Cpf");
                        string endereco = reader.GetString("Endereço");
                        clientes.Add(new Usuario(id, nome, telefone, cpf, endereco));
                    }
                    return clientes;
                }
            }
            catch
            {
                throw;
            }
            
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                using (MySqlConnection conexao = _conexao.GetConnection())
                {
                    conexao.Open();
                    string cmd = "SELECT * FROM api4 WHERE id = @id";
                    MySqlCommand comando = new MySqlCommand(cmd, conexao);
                    comando.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        string nome = reader.GetString("Nome");
                        long telefone = reader.GetInt64("Telefone");
                        long cpf = reader.GetInt64("Cpf");
                        string endereco = reader.GetString("Endereço");
                        return new Usuario(id, nome, telefone, cpf, endereco);
                    }
                    else
                    {
                        throw new Exception("Usuário não encontrado.");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Criar(Usuario cliente)
        {
            try
            {
                using(MySqlConnection conexao = _conexao.GetConnection())
                {
                    conexao.Open();
                    string cmd = "INSERT INTO api4 (Nome, Telefone, Cpf, Endereço) VALUES (@nome, @telefone, @cpf, @endereco)";
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

        public void Atualizar(Usuario cliente, int id)
        {
            try
            {
                using (MySqlConnection conexao = _conexao.GetConnection())
                {
                    conexao.Open();
                    string cmd = "UPDATE api4 SET nome = @nome, telefone = @telefone, cpf = @cpf, endereco = @endereco WHERE id = @id";
                    MySqlCommand comando = new MySqlCommand(cmd, conexao);
                    comando.Parameters.AddWithValue("@id", id);
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

        public void Deletar(int id)
        {
            try
            {
                using (MySqlConnection conexao = _conexao.GetConnection())
                {
                    conexao.Open();
                    string cmd = "DELETE FROM api4 WHERE id = @id";
                    MySqlCommand comando = new MySqlCommand(cmd, conexao);
                    comando.Parameters.AddWithValue("@id", id);
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
