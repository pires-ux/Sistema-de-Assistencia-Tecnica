
using Api4;
using AssistenciaApi.Context;
using AssistenciaApi.DTOs;
using AssistenciaApi.Interface.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaApi.Repository
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly AssistenciaContext _context;
        public ServicoRepository(AssistenciaContext context)
        {
            _context = context;
        }


        public List<ServicoMostraDto> Listar(int idcliente)
        {
            List<ServicoMostraDto> ordems = new List<ServicoMostraDto>();
            ordems = _context.OrdemDeServicos.Select(x => new ServicoMostraDto
            {
                Aparelho = x.Aparelho,
                Descricao = x.Descrição,
                Valor = x.Valor,
                Status = x.Status
            }).ToList();
            return ordems;
        }

        public OrdemDeServico Mostrar(int id)
        {
            OrdemDeServico ordem = _context.OrdemDeServicos.Find(id);
            return ordem;
        }

        public void Criar(OrdemDeServico ordem)
        {
            _context.OrdemDeServicos.Add(ordem);
            _context.SaveChanges();
             
        }


    }
}
