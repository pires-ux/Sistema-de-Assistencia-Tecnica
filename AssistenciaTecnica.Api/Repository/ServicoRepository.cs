using Api4;
using AssistenciaApi.Context;
using AssistenciaApi.DTOs;
using AssistenciaApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaApi.Repository
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly AssistenciaContext _context;

        public ServicoRepository(AssistenciaContext context)
        {
            _context = context;
        }

        public async Task<OrdemDeServico?> Buscar(int id)
        {
            return await _context.OrdemDeServicos
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ServicoMostraDto>> ClienteListar(int clienteId)
        {
            return await _context.OrdemDeServicos
                .Where(x => x.ClienteId == clienteId)
                .Select(x => new ServicoMostraDto
                {
                    Aparelho = x.Aparelho,
                    Descricao = x.Descrição,
                    Valor = x.Valor,
                    Status = x.Status
                })
                .ToListAsync();
        }

        public async Task Criar(OrdemDeServico ordem)
        {
            _context.OrdemDeServicos.Add(ordem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ServicoFuncionarioDTO>> FuncionarioListar()
        {
            return await _context.OrdemDeServicos
                .Select(x => new ServicoFuncionarioDTO
                {
                    Id = x.Id,
                    Cliente = x.Cliente != null ? x.Cliente.Nome : "Cliente não encontrado",
                    Aparelho = x.Aparelho,
                    Valor = x.Valor,
                    Data = DateOnly.FromDateTime(x.Data),
                    Status = x.Status,
                    Telefone = x.Cliente != null ? x.Cliente.Telefone : ""
                })
                .ToListAsync();
        }

        public async Task<bool> AtualizarServico(AtualizarServicoDTO atualizar)
        {
            var servico = await _context.OrdemDeServicos
                .FirstOrDefaultAsync(x => x.Id == atualizar.Id);

            if (servico == null)
            {
                return false;
            }

            servico.Status = atualizar.Status;
            servico.Valor = atualizar.Valor;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}