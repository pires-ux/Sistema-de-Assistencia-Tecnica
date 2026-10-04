using Api4;
using AssistenciaApi.Context;
using AssistenciaApi.DTOs;
using AssistenciaApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using ZstdSharp.Unsafe;

namespace AssistenciaApi.Repository
{
    public class ClienteRepository: IClienteRepository
    {

        private readonly AssistenciaContext _context;
        public ClienteRepository(AssistenciaContext context)
        {
            _context = context;
        }



        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = _context.Clientes.ToList();
            return clientes;
        }

        public Cliente Mostrar(int id)
        {
            Cliente cliente = _context.Clientes.Find(id);
            return cliente;
        }

        public void Criar(CriarOrdemDeServicoDTO dados)
        {
            var cliente = new Cliente
            {
                Nome = dados.Cliente.Nome,
                Email = dados.Cliente.Email,
                Telefone = dados.Cliente.Telefone,
                
            };
            
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            var clientelogado = _context.Clientes.First(c => c.Email == cliente.Email);

            var service = new OrdemDeServico
            {
                ClienteId = clientelogado.Id,
                Aparelho = dados.Aparelho,
                Cliente = clientelogado,
                Descrição = dados.Descrição,
                Data = dados.Data,
                Status = dados.Status,
                Valor = dados.Valor,
            };
            _context.OrdemDeServicos.Add(service);
            _context.SaveChanges();
        }

        public async Task<Cliente> Login(LoginClienteDTO login)
        {
            var resultado = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == login.Email);
            return resultado;
        }

        public async Task<bool> VerificarEmail(string email)
        {

            bool existe = await _context.Clientes.AnyAsync(c => email == c.Email);
            return existe;
        }

        public async Task<bool> VerificarTelefone(string telefone)
        {
            var existe = await _context.Clientes.AnyAsync(c => telefone == c.Telefone);
            return existe;
        }
    }
}
