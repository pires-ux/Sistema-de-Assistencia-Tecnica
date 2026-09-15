using AssistenciaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api4.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ServiceCliente _service;
        public ClienteController(ServiceCliente service)
        {
            _service = service;
        }

        List<Cliente> usuarios = new List<Cliente>();

        [HttpGet]
        public IActionResult Listar()
        {
            usuarios = _service.Listar();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult EncontrarUsuario(int id)
        {
            Cliente cliente = _service.Mostrar(id);
            return Ok(cliente);
        }

        [HttpPost("Criar")]
        public IActionResult Criar(CriarClienteDto cliente)
        {
            if(_service.VerificarEmail(cliente))
            {
                return BadRequest("Email já cadastrado.");
            }
            if (_service.VerificarTelefone(cliente))
            {                    
                return BadRequest("Telefone já cadastrado.");
            }
            var cl =_service.Criar(cliente);//retorna cliente com o id
            return Ok(cl);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginClienteDTO login)
        {
            if (await _service.Login(login))
            {
                return Ok("Conta logada com sucesso.");
            }
            return BadRequest("Email ou senha inválidos.");
        }

    }
}
