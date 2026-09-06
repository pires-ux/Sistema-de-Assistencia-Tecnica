using AssistenciaApi.DTOs;
using AssistenciaApi.Interface.Service;
using AssistenciaApi.Models;
using AssistenciaApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;
        public FuncionarioController(IFuncionarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Cadastro(FuncionarioCadastroDTO cadastroDTO)
        {
            _service.Cadastro(cadastroDTO);
            return Ok(cadastroDTO);
        }

        [HttpPost("Login")]
        public IActionResult Login(FuncionarioLoginDTO loginDTO)
        {
            if (!_service.Login(loginDTO)) return BadRequest("email ou senha incorreta");
            return Ok("login bem sucedido");
        }
    }
}
