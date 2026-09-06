using AssistenciaApi.DTOs;
using AssistenciaApi.Interface.Repository;
using AssistenciaApi.Interface.Service;
using BCrypt.Net;


namespace Api4
{
    public class ServiceCliente : IClienteService
    {
        private readonly IClienteRepository _repository;

        List<Cliente> clientes = new List<Cliente>();
        public ServiceCliente(IClienteRepository repository)
        {
            _repository = repository;
        }

        public List<Cliente> Listar()
        {
            return _repository.Listar();
        }

        public Cliente Mostrar(int id)
        {
            return _repository.Mostrar(id);
        }

        public void Criar(CriarClienteDto clienteGto)
        {
            Cliente cliente = new Cliente()
            {
                Id = clienteGto.Id,
                Nome = clienteGto.Nome,
                Email = clienteGto.Email,
                Telefone = clienteGto.Telefone,
            };
            _repository.Criar(cliente);
        }

        public bool VerificarTelefone(CriarClienteDto clienteGto)
        { 
            if(clientes.Any(c => c.Telefone == clienteGto.Telefone))
            {
                return true;
            }
            
            return false;
        }

        public bool VerificarEmail(CriarClienteDto clienteGto)
        {
            if (clientes.Any(c => c.Email == clienteGto.Email))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Login(LoginClienteDTO login)
        {
            Cliente cliente = await _repository.Login(login);
            if (cliente != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
