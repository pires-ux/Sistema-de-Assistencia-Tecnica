using Api4;
using AssistenciaApi.DTOs;

namespace AssistenciaApi.Interface.Service
{
    public interface IClienteService
    {
        public List<Cliente> Listar();

        public Cliente Mostrar(int id);

        public void Criar(CriarClienteGto clienteGto);

        public bool VerificarNome(CriarClienteGto clienteGto);

        public bool VerificarTelefone(CriarClienteGto clienteGto);

        public bool VerificarCpf(CriarClienteGto clienteGto);

        public bool VerificarEndereco(CriarClienteGto clienteGto);
    }
}
