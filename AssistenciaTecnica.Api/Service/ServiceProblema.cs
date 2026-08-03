namespace Api4
{
    public class ServiceProblema
    {
        private readonly SqlProblema _sql;

        public ServiceProblema(SqlProblema sql)
        {
            _sql = sql;
        }

        List<OrdemDeServiço> serviços = new List<OrdemDeServiço>();
        public List<OrdemDeServiço> Get(int idcliente)
        {
            serviços = _sql.Listar(idcliente);
            return serviços;
        }

        public void Post(OrdemDeServiço ordem)
        {
            _sql.Adicionar(ordem);
        }

        
    }
}
