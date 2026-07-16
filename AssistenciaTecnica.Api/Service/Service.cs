namespace Api4
{
    public class Service
    {
        private readonly Sql _sql;

        public Service(Sql sql)
        {
            _sql = sql;
        }
        
        List<Usuario> clientes = new List<Usuario>();

        public bool VerificarCpfExistente(Usuario usuario)
        {
            clientes = _sql.Listar();
            foreach (var cliente in clientes)
            {
                if (cliente.Cpf == usuario.Cpf)
                {
                    return false;
                }
            }
            return true;
        }

        public bool VerificarUsuario(Usuario usuario)
        {
            if(usuario.Cpf < 10000000000 || usuario.Cpf > 99999999999)
            {
                return false;
            }
            if (usuario.Telefone < 10000000000 || usuario.Telefone > 99999999999)
            {
                return false;
            }
            if(usuario.Nome.Length < 3 || usuario.Nome.Length > 50)
            {
                return false;
            }
            return true;
        }

        public bool VerificarTelefoneExistente(Usuario usuario)
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
        public List<Usuario> Listar()
        {
            clientes = _sql.Listar();
            return clientes;
        }

        public List<Usuario> EncontrarUsuario(int id)
        {
            
            clientes.Add(_sql.ObterPorId(id));
            return clientes;
        }
        public void Criar(Usuario cliente)
        {
            _sql.Criar(cliente);
        }
    }
}
