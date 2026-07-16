namespace Api4
{
    public class ServiceCliente
    {
        private readonly Sql _sql;

        public ServiceCliente(Sql sql)
        {
            _sql = sql;
        }
        
        List<Cliente> clientes = new List<Cliente>();

        public bool VerificarCpfExistente(Cliente cliente)
        {
            clientes = _sql.Listar();
            foreach (var item in clientes)
            {
                if (item.Cpf == cliente.Cpf)
                {
                    return false;
                }
            }
            return true;
        }

        public bool VerificarUsuario(Cliente usuario)
        {
            if(usuario.Cpf.Length != 11)
            {
                return false;
            }
            if (usuario.Telefone.Length != 11)
            {
                return false;
            }
            if(usuario.Nome.Length < 3 || usuario.Nome.Length > 50)
            {
                return false;
            }
            return true;
        }

        public bool VerificarTelefoneExistente(Cliente usuario)
        {
            clientes = _sql.Listar();
            foreach (var cliente in clientes)
            {
                if (cliente.Telefone == usuario.Telefone)
                {
                    return false;
                }
            }
            return true;
        }
        public List<Cliente> Listar()
        {
            clientes = _sql.Listar();
            return clientes;
        }

        public List<Cliente> EncontrarUsuario(int id)
        {
            
            clientes.Add(_sql.ObterPorId(id));
            return clientes;
        }
        public void Criar(Cliente cliente)
        {
            _sql.Criar(cliente);
        }
    }
}
