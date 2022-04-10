using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;


namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidasController : ControllerBase
    {
        private readonly IBebidaAplicacao _bebidaAplicacao;

        public BebidasController(IBebidaAplicacao bebidaAplicacao)
        {
            _bebidaAplicacao = bebidaAplicacao;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_bebidaAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os clientes.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Encontrar(int id)
        {
            try
            {
                return Ok(_bebidaAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Bebida bebida)
        {
            try
            {
                _bebidaAplicacao.Editar(bebida);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Adicionar(Bebida bebida)
        {
            try
            {
                _bebidaAplicacao.Adicionar(bebida);
                return Created("Get", new { id = bebida.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _bebidaAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
