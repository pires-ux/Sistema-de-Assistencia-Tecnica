using Api4;

namespace AssistenciaApi.Interface.Repository
{
    public interface IServicoRepository
    {
        public List<OrdemDeServico> Listar();

        public OrdemDeServico Mostrar(int id);
    }
}
