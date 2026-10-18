using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Repository.Interface
{
    public interface IServicoRepository
    {
        Task<List<ServicoMostraDto>> ClienteListar(int clienteId);
        Task Criar(OrdemDeServico ordem);
        Task<List<ServicoFuncionarioDTO>> FuncionarioListar();
        Task<bool> AtualizarServico(AtualizarServicoDTO atualizar);
        Task<OrdemDeServico?> Buscar(int id);
    }
}