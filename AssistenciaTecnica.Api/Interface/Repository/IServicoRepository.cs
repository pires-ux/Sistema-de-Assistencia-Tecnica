using Api4;

namespace AssistenciaApi.Interface.Repository
{
    public interface IServicoRepository
    {
        public List<OrdemDeServico> Listar(int clienteid);

        public OrdemDeServico Mostrar(int id);
    }
}
