using AssistenciaApi.DTOs;
using AssistenciaApi.Models;

namespace AssistenciaApi.Repository.Interface
{
    public interface IFuncionarioRepository
    {
        public void Cadastro(Funcionarios funcionarios);
        public void Login(FuncionarioLoginDTO loginDTO);
        public Funcionarios VerificarEmail(FuncionarioLoginDTO loginDTO);
    }
}
