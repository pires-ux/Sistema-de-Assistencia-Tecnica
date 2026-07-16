using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProblemaController : Controller
    {
        private readonly ServiceProblema _service;

        public ProblemaController(ServiceProblema service)
        {
            _service = service;

        }

        List<OrdemDeServiço> serviços = new List<OrdemDeServiço>();
        [HttpGet("{idcliente}")]
        public List<OrdemDeServiço> Get(int idcliente)
        {
            serviços = _service.Get(idcliente);
            return serviços;
        }

        [HttpPost]
        public IActionResult Post(OrdemDeServiço ordem)
        {
            _service.Post(ordem);
            return Ok(ordem);
        }


    }
}
