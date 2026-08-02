
using Api4;
using AssistenciaApi.Context;
using AssistenciaApi.Interface.Repository;

namespace AssistenciaApi.Repository
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly AssistenciaContext _context;
        public ServicoRepository(AssistenciaContext context)
        {
            _context = context;
        }


        public List<OrdemDeServico> Listar(int idcliente)
        {
            List<OrdemDeServico> ordems = new List<OrdemDeServico>();
            ordems = _context.OrdemDeServicos.ToList();
            return ordems;
        }

        public OrdemDeServico Mostrar(int id)
        {
            OrdemDeServico ordem = _context.OrdemDeServicos.Find(id);
            return ordem;
        }

        public void Adicionar(OrdemDeServico ordem)
        {
            _context.OrdemDeServicos.Add(ordem);
            _context.SaveChanges();
        }
    }
}
