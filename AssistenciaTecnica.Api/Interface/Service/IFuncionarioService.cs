using AssistenciaApi.DTOs;

namespace AssistenciaApi.Interface.Service
{
    public interface IFuncionarioService
    {
        public void Cadastro(FuncionarioCadastroDTO cadastroDTO);

        public void Login(FuncionarioLoginDTO loginDTO);
    }
}
