using Api4;
using AssistenciaApi.Context;
using AssistenciaApi.DTOs;
using AssistenciaApi.Interface.Repository;
using ZstdSharp.Unsafe;

namespace AssistenciaApi.Repository
{
    public class ClienteRepository: IClienteRepository
    {

        private readonly AssistenciaContext _context;
        public ClienteRepository(AssistenciaContext context)
        {
            _context = context;
        }



        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = _context.Clientes.ToList();
            return clientes;
        }

        public Cliente Mostrar(int id)
        {
            Cliente cliente = _context.Clientes.Find(id);
            return cliente;
        }

        public void Criar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public bool Login(LoginClienteDTO login)
        {
            bool resultado = _context.Clientes.Any(c => c.Email == login.Email && c.Senha == login.Senha);
            return resultado;
        }
    }
}
