using Api4;
using AssistenciaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaApi.Interface.Repository
{
    public interface IServicoRepository
    {
        public List<ServicoMostraDto> Listar(int clienteid);

        public OrdemDeServico Mostrar(int id);

        public void Criar(OrdemDeServico ordem);
    }
}
