using Api4;

namespace AssistenciaApi.Interface.Service
{
    public interface IClienteService
    {
        public List<Cliente> Listar();

        public Cliente Mostrar(int id);
    }
}
