using AssistenciaApi.Context;
using AssistenciaApi.DTOs;
using AssistenciaApi.Interface.Repository;
using AssistenciaApi.Models;

namespace AssistenciaApi.Repository
{
    public class FuncionarioRepository: IFuncionarioRepository
    {
        private readonly AssistenciaContext _context;
        public FuncionarioRepository(AssistenciaContext context)
        {
            _context = context;
        }
        public void Cadastro(Funcionarios funcionarios)
        {
            _context.Funcionarios.Add(funcionarios);
            _context.SaveChanges();
        }

        public void Login(FuncionarioLoginDTO loginDTO)
        {

        }

        public Funcionarios VerificarEmail(FuncionarioLoginDTO loginDTO)
        {
            var usuario = _context.Funcionarios.FirstOrDefault(x => x.Email == loginDTO.Email);
            return usuario;
        }
    }
}
