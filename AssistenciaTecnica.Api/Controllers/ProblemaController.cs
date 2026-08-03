using AssistenciaApi.DTOs;
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

        List<ServicoMostraDto> serviços = new List<ServicoMostraDto>();
        [HttpGet("{idcliente}")]
        public IActionResult Get(int idcliente)
        {
            serviços = _service.Listar(idcliente);
            if(serviços == null)
        {
                return NotFound();
        }
            return Ok(serviços);
        }

        [HttpPost]
        public IActionResult Post(OrdemDeServico ordem)
        {
            _service.Criar(ordem);
            return Ok("criada com sucesso!");
        }


    }
}
