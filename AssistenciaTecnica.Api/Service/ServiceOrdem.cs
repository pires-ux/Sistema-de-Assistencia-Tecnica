using AssistenciaApi.Interface.Repository;
using AssistenciaApi.Interface.Service;

namespace Api4
{
    public class ServiceOrdem: IOrdemService
    {
        private readonly IServicoRepository _repository;

        public ServiceOrdem(IServicoRepository repository)
        {
            _repository = repository;
        }

        List<OrdemDeServico> serviços = new List<OrdemDeServico>();
        public List<OrdemDeServico> Listar(int clienteid)
        {
            serviços = _repository.Listar(clienteid);
            return serviços;
        }

        public OrdemDeServico Mostrar(int id)
        {
            OrdemDeServico ordem = _repository.Mostrar(id);
            return ordem;
        }

        public void Criar(OrdemDeServico ordem)
        {
            _repository.Criar(ordem);
        }


    }
}
