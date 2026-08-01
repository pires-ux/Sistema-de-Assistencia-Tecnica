using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProblemaController : Controller
    {
        private readonly ServiceOrdem _service;

        public ProblemaController(ServiceOrdem service)
        {
            _service = service;

        }

        List<OrdemDeServico> serviços = new List<OrdemDeServico>();
        [HttpGet("{idcliente}")]
        public List<OrdemDeServico> Get(int idcliente)
        {
            serviços = _service.Listar(idcliente);
            return serviços;
        }

        [HttpPost]
        public IActionResult Post(OrdemDeServico ordem)
        {
            return BadRequest();
        }


    }
}
