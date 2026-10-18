using AssistenciaApi.DTOs;
using AssistenciaApi.Repository.Interface;
using AssistenciaApi.Service.Interface;

namespace Api4
{
    public class ServiceOrdem : IOrdemService
    {
        private readonly IServicoRepository _repository;
        private readonly ILogger<ServiceOrdem> _log;

        public ServiceOrdem(IServicoRepository repository, ILogger<ServiceOrdem> log)
        {
            _log = log;
            _repository = repository;
        }

        public Task<List<ServicoMostraDto>> ClienteListar(int clienteId)
        {
            return _repository.ClienteListar(clienteId);
        }

        public Task Criar(OrdemDeServico ordem)
        {
            return _repository.Criar(ordem);
        }

        public Task<List<ServicoFuncionarioDTO>> FuncionarioListar()
        {
            return _repository.FuncionarioListar();
        }

        public Task<bool> AtualizarServico(AtualizarServicoDTO atualizar)
        {
            return _repository.AtualizarServico(atualizar);
        }

        public async Task<ServicoFuncionarioDTO?> BuscarId(int id)
        {
            var ordem = await _repository.Buscar(id);
            if (ordem == null)
            {
                return null;
            }

            return new ServicoFuncionarioDTO
            {
                Id = ordem.Id,
                Cliente = ordem.Cliente?.Nome ?? "Cliente não encontrado",
                Aparelho = ordem.Aparelho,
                Valor = ordem.Valor,
                Data = DateOnly.FromDateTime(ordem.Data),
                Status = ordem.Status,
                Telefone = ordem.Cliente?.Telefone ?? ""
            };
        }
    }
}