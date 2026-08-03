using Api4;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaApi.Interface.Repository
{
    public interface IServicoRepository
    {
        public List<OrdemDeServico> Listar(int clienteid);

        public OrdemDeServico Mostrar(int id);

        public void Criar(OrdemDeServico ordem);
    }
}
