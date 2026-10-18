using AssistenciaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ServiceCliente _service;

        public ClienteController(ServiceCliente service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id:int}")]
        public IActionResult EncontrarUsuario(int id)
        {
            var cliente = _service.Mostrar(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(cliente);
        }

        [HttpPost("CriarComServico")]
        public async Task<IActionResult> CriarComServico([FromBody] CriarOrdemDeServicoDTO dados)
        {
            if (dados?.Cliente == null)
            {
                return BadRequest("Os dados do cliente são obrigatórios.");
            }

            var cliente = await _service.Criar(dados);
            if (cliente == null)
            {
                return Conflict("E-mail ou telefone já cadastrado.");
            }

            return Ok(cliente);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginClienteDTO login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.Email))
            {
                return BadRequest("Informe um e-mail válido.");
            }

            if (await _service.Login(login))
            {
                return Ok("Conta localizada com sucesso.");
            }

            return Unauthorized("E-mail inválido.");
        }
    }
}