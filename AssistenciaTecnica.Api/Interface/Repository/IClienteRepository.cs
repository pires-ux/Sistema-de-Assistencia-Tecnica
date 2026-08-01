using Api4;

namespace AssistenciaApi.Interface.Repository
{
    public interface IClienteRepository
    {
        public List<Cliente> Listar();
        
        public Cliente Mostrar(int id);

        public void Criar(Cliente cliente);
    }
}
