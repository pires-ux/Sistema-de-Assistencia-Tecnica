using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Repository.Interface
{
    public interface IClienteRepository
    {
        public List<Cliente> Listar();
        
        public Cliente Mostrar(int id);

        public void Criar(CriarOrdemDeServicoDTO dados);

        public Task<Cliente> Login(LoginClienteDTO login);

        public Task<bool> VerificarEmail(string email);

        public Task<bool> VerificarTelefone(string telefone);
    }
}
