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
        public async Task<List<ServicoMostraDto>> ClienteListar(int clienteid)
        {
            serviços = await _repository.ClienteListar(clienteid);
            return serviços;
        }


        public async void Criar(OrdemDeServico ordem)
        {
            _repository.Criar(ordem);
        }

        public async Task<List<ServicoFuncionarioDTO>> FuncionarioListar()
        {
            var servico = await _repository.FuncionarioListar();
            return servico;
        }
    }
}
