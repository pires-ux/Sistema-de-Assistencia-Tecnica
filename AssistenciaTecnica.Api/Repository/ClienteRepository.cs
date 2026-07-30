using Api4;
using AssistenciaApi.Context;
using AssistenciaApi.Interface;
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
    }
}
