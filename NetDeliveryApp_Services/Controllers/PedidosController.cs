using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;

namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoAplicacao _pedidoAplicacao;

        public PedidosController(IPedidoAplicacao pedidoAplicacao)
        {
            _pedidoAplicacao = pedidoAplicacao;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_pedidoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os pedidos.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        public IActionResult Encontrar(int id)
        {
            try
            {
                return Ok(_pedidoAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromBody] PedidoDTO pedidoDTO)
        {
            try
            {
                _pedidoAplicacao.Editar(pedidoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        public IActionResult Adicionar(PedidoDTO pedidoDTO)
        {
            try
            {
                _pedidoAplicacao.Adicionar(pedidoDTO);
                return Created("Get", new { id = pedidoDTO.Id });
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
                _pedidoAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
