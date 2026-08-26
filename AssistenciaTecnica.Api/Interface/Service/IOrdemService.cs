using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Interface.Service
{
    public interface IOrdemService
    {
        public Task<List<ServicoMostraDto>> ClienteListar(int clienteid);

        public void Criar(OrdemDeServico ordem);

        public Task<List<ServicoFuncionarioDTO>> FuncionarioListar();
    }
}
