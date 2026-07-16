using MySql.Data.MySqlClient;

namespace Api4
{
    public class Conexao
    {
        private readonly string _config;

        public Conexao(IConfiguration config)
        {
            _config = config.GetConnectionString("Banco");
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_config);
        }
    }
}
