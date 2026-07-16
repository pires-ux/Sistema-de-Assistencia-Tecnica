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
            usuarios = _service.EncontrarUsuario(id);
            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {                    
            if (!_service.VerificarUsuario(cliente)) return BadRequest("Dados do usuário inválidos.");
            if (!_service.VerificarCpfExistente(cliente)) return BadRequest("CPF já cadastrado.");
            if (!_service.VerificarTelefoneExistente(cliente)) return BadRequest("Telefone já cadastrado.");
            
            _service.Criar(cliente);
            return Ok(cliente);
        }

    }
}
