using Microsoft.AspNetCore.Mvc;

namespace Api4.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly Service _service;
        public ClienteController(Service service)
        {
            _service = service;
        }

        List<Usuario> usuarios = new List<Usuario>();

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
        public IActionResult Criar(Usuario cliente)
        {                    
            if (!_service.VerificarUsuario(cliente)) return BadRequest("Dados do usuário inválidos.");
            if (!_service.VerificarCpfExistente(cliente)) return BadRequest("CPF já cadastrado.");
            if (!_service.VerificarTelefoneExistente(cliente)) return BadRequest("Telefone já cadastrado.");
            
            _service.Criar(cliente);
            return Ok(cliente);
        }

    }
}
