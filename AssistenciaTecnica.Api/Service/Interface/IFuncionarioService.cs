using AssistenciaApi.DTOs;

namespace AssistenciaApi.Service.Interface
{
    public interface IFuncionarioService
    {
        public void Cadastro(FuncionarioCadastroDTO cadastroDTO);

        public bool Login(FuncionarioLoginDTO loginDTO);
    }
}
