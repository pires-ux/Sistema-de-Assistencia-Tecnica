 using Api4;
using AssistenciaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaApi.Interface.Repository
{
    public interface IServicoRepository
    {
        public Task<List<ServicoMostraDto>> ClienteListar(int clienteid);

        public void Criar(OrdemDeServico ordem);

        public Task<List<ServicoFuncionarioDTO>> FuncionarioListar();
    }
}
