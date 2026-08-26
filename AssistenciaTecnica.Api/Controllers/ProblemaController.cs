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
        public async Task<IActionResult> Get(int idcliente)
        {
            serviços = await _service.ClienteListar(idcliente);
            if(serviços == null)
        {
                return NotFound();
        }
            return Ok(serviços);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdemDeServico ordem)
        {
            _service.Criar(ordem);
            return Ok("criada com sucesso!");
        }


        [HttpGet("Funcionario")]
        public async Task<IActionResult> GetResult()
        {
            List<ServicoFuncionarioDTO> servico = await _service.FuncionarioListar();
            return Ok(servico);
        }
    }
}
