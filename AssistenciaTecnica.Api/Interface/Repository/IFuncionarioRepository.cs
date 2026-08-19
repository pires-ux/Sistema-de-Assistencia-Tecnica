using AssistenciaApi.DTOs;

namespace AssistenciaApi.Interface.Repository
{
    public interface IFuncionarioRepository
    {
        public void Cadastro(FuncionarioCadastroDTO cadastroDTO);
        public void Login(FuncionarioLoginDTO loginDTO);
    }
}
