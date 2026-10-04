using Api4;
using AssistenciaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaApi.Repository.Interface
{
    public interface IServicoRepository
    {
        public Task<List<ServicoMostraDto>> ClienteListar(int clienteid);

        public void Criar(OrdemDeServico ordem);

        public Task<List<ServicoFuncionarioDTO>> FuncionarioListar();

        public void AtualizarServico(AtualizarServicoDTO atualizar);

        public Task<OrdemDeServico> Buscar(int id);
    }
}
