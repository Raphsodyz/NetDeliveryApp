using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
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

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_bebidaAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os bebidas.");
            }
        }

        [HttpGet("Encontrar/{id}")]
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

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromBody] BebidaDTO bebidaDTO)
        {
            try
            {
                _bebidaAplicacao.Editar(bebidaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        public IActionResult Adicionar(BebidaDTO bebidaDTO)
        {
            try
            {
                _bebidaAplicacao.Adicionar(bebidaDTO);
                return Created("Get", new { id = bebidaDTO.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
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
