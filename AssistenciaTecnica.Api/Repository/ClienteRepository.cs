using Api4;
using AssistenciaApi.Context;
using AssistenciaApi.DTOs;
using AssistenciaApi.Repository.Interface;
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

        public async Task<Cliente> Login(LoginClienteDTO login)
        {
            var resultado = _context.Clientes.FirstOrDefault(c => c.Email == login.Email);
            return resultado;
        }
    }
}
