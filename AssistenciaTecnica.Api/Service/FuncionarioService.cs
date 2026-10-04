using AssistenciaApi.DTOs;
using AssistenciaApi.Models;
using AssistenciaApi.Repository;
using AssistenciaApi.Repository.Interface;
using AssistenciaApi.Service.Interface;
using Org.BouncyCastle.Crypto.Generators;

namespace AssistenciaApi.Service
{
    public class FuncionarioService: IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;
        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }
        public void Cadastro(FuncionarioCadastroDTO cadastroDTO)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(cadastroDTO.Senha);
            var funcionarios = new Funcionarios
            {
                Nome = cadastroDTO.Nome,
                Email = cadastroDTO.Email,
                Senha = hash
            };
            _repository.Cadastro(funcionarios);
        }

        public bool Login(FuncionarioLoginDTO loginDTO)
        {
            var funcionario = _repository.VerificarEmail(loginDTO);
            if (funcionario == null)
            {
                return false;
            }

            var igual = BCrypt.Net.BCrypt.Verify(loginDTO.Senha, funcionario.Senha);
            if (!igual)
            {
                return false;
            }

            return true;
        }
    }
}
