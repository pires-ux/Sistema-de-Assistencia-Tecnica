using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Interface.Service
{
    public interface IClienteService
    {
        public List<Cliente> Listar();

        public Cliente Mostrar(int id);

        public void Criar(CriarClienteDto clienteGto);

        public bool VerificarTelefone(CriarClienteDto clienteGto);

        public bool VerificarEmail(CriarClienteDto clienteGto);

        public Task<bool> Login(LoginClienteDTO login);

    }
}
