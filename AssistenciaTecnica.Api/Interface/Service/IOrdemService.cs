using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Interface.Service
{
    public interface IOrdemService
    {
        public List<ServicoMostraDto> Listar(int clienteid);

        public OrdemDeServico Mostrar(int id);

        public void Criar(OrdemDeServico ordem);
    }
}
