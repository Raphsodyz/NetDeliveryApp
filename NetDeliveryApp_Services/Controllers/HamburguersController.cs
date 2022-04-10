using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;

namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamburguersController : ControllerBase
    {
        private readonly IHamburguerAplicacao _hamburguerAplicacao;

        public HamburguersController(IHamburguerAplicacao hamburguerAplicacao)
        {
            _hamburguerAplicacao = hamburguerAplicacao;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_hamburguerAplicacao.Listar());
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
                return Ok(_hamburguerAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Hamburguer hamburguer)
        {
            try
            {
                _hamburguerAplicacao.Editar(hamburguer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Adicionar(Hamburguer hamburguer)
        {
            try
            {
                _hamburguerAplicacao.Adicionar(hamburguer);
                return Created("Get", new { id = hamburguer.Id });
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
                _hamburguerAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
