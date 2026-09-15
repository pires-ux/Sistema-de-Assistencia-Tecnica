
using Api4;
using AssistenciaApi.Context;
using AssistenciaApi.DTOs;
using AssistenciaApi.Repository.Interface;
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

        public async Task<OrdemDeServico> Buscar(int id)
        {
            var servico = _context.OrdemDeServicos.Find(id);
            return servico;
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
                Id = x.Id,
                Cliente = x.Cliente.Nome,
                Aparelho = x.Aparelho,              
                Valor = x.Valor,
                Data = DateOnly.FromDateTime(x.Data),
                Status = x.Status,
                Telefone = x.Cliente.Telefone
            }).ToList();

            return service;
        }

        public void AtualizarServico(AtualizarServicoDTO atualizar)
        {
            OrdemDeServico servico = _context.OrdemDeServicos.Find(atualizar.Id);
            servico.Status = atualizar.Status;
            servico.Valor = atualizar.Valor;
            _context.SaveChanges();
        }


    }
}
