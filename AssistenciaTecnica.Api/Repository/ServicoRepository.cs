
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


        public async Task<List<ServicoMostraDto>> ClienteListar(int idcliente)
        {
            
            var ordems = _context.OrdemDeServicos.Select(x => new ServicoMostraDto
            {
                Aparelho = x.Aparelho,
                Descricao = x.Descrição,
                Valor = x.Valor,
                Status = x.Status
            }).ToList();
            return ordems;
        }


        public async void Criar(OrdemDeServico ordem)
        {
            _context.OrdemDeServicos.Add(ordem);
            _context.SaveChanges();
             
        }

        public async Task<List<ServicoFuncionarioDTO>> FuncionarioListar()
        {
            List<ServicoFuncionarioDTO> service = _context.OrdemDeServicos.Select(x => new ServicoFuncionarioDTO
            {
                Cliente = x.Cliente.Nome,
                Aparelho = x.Aparelho,
                Valor = x.Valor,
                Status = x.Status
            }).ToList();

            return service;
        }
    }
}
