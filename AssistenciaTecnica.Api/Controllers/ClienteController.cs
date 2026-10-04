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

        [HttpPost("CriarComServico")]
        public async Task<IActionResult> CriarComServico(CriarOrdemDeServicoDTO dados)
        {
            
            var cl = await _service.Criar(dados);
            if(cl == null)
            {
                BadRequest("email ou telefone já cadastrado");
            }
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
