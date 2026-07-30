using Api4;

namespace AssistenciaApi.Interface
{
    public interface IClienteRepository
    {
        public List<Cliente> Listar();
        
        public Cliente Mostrar(int id);
    }
}
