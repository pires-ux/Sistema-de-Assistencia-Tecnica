using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Repository.Interface
{
    public interface IClienteRepository
    {
        public List<Cliente> Listar();
        
        public Cliente Mostrar(int id);

        public void Criar(Cliente cliente);

        public Task<Cliente> Login(LoginClienteDTO login);
    }
}
