using Api4;

namespace AssistenciaApi.Interface.Service
{
    public interface IOrdemService
    {
        public List<OrdemDeServico> Listar();

        public OrdemDeServico Mostrar(int id);
    }
}
