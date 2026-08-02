using AssistenciaApi.DTOs;
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

        List<ServicoMostraDto> serviços = new List<ServicoMostraDto>();
        public List<ServicoMostraDto> Listar(int clienteid)
        {
            foreach (var servico in _repository.Listar(clienteid))
            {
                serviços.Add(new ServicoMostraDto
                {
                    Aparelho = servico.Aparelho,
                    Descricao = servico.Descrição,
                    Valor = servico.Valor,
                    Status = servico.Status
                });
            }
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
