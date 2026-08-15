using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Interface.Repository
{
    public interface IClienteRepository
    {
        public List<Cliente> Listar();
        
        public Cliente Mostrar(int id);

        public void Criar(Cliente cliente);

        public bool Login(LoginClienteDTO login);
    }
}
