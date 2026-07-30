using Api4;

namespace AssistenciaApi.Interface
{
    public interface IServicoRepository
    {
        public List<OrdemDeServico> Listar();

        public OrdemDeServico Mostrar(int id);
    }
}
