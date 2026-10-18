using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Service.Interface
{
    public interface IOrdemService
    {
        Task<List<ServicoMostraDto>> ClienteListar(int clienteId);
        Task Criar(OrdemDeServico ordem);
        Task<List<ServicoFuncionarioDTO>> FuncionarioListar();
        Task<bool> AtualizarServico(AtualizarServicoDTO atualizar);
        Task<ServicoFuncionarioDTO?> BuscarId(int id);
    }
}