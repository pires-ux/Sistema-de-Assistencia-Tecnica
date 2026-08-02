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

        [HttpPost]
        public IActionResult Criar(CriarClienteDto cliente)
        {
            if(_service.VerificarCpf(cliente))
            {
                return BadRequest("CPF já cadastrado.");
            }
            if (_service.VerificarTelefone(cliente))
            {
                return BadRequest("Telefone já cadastrado.");
            }
            _service.Criar(cliente);
            return Ok(cliente);
        }

    }
}
