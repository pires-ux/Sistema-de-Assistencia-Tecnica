using AssistenciaApi.Interface.Repository;
using AssistenciaApi.Interface.Service;

namespace Api4
{
    public class ServiceCliente : IClienteService
    {
        private readonly IClienteRepository _repository;

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

    }
}
