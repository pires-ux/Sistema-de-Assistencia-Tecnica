using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Service.Interface
{
    public interface IClienteService
    {
        public List<Cliente> Listar();

        public Cliente Mostrar(int id);

        public Task<Cliente> Criar(CriarOrdemDeServicoDTO dados);

        public bool VerificarTelefone(CriarClienteDto clienteGto);

        public bool VerificarEmail(CriarClienteDto clienteGto);

        public Task<bool> Login(LoginClienteDTO login);

    }
}
