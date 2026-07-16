namespace Api4
{
    public class ServiceProblema
    {
        private readonly SqlProblema _sql;

        public ServiceProblema(SqlProblema sql)
        {
            _sql = sql;
        }

        List<OrdemDeServico> serviços = new List<OrdemDeServico>();
        public List<OrdemDeServico> Get(int idcliente)
        {
            serviços = _sql.Listar(idcliente);
            return serviços;
        }

        public void Post(OrdemDeServico ordem)
        {
            _sql.Adicionar(ordem);
        }

        
    }
}
