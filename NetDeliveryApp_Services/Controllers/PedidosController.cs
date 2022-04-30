using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;

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
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _pedidoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os pedidos.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        public async Task<IActionResult> Encontrar(int id)
        {
            try
            {
                return Ok(await _pedidoAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar([FromBody] PedidoDTO pedidoDTO)
        {
            try
            {
                await _pedidoAplicacao.Editar(pedidoDTO);
                await _pedidoAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> Adicionar(PedidoDTO pedidoDTO)
        {
            try
            {
                _pedidoAplicacao.Adicionar(pedidoDTO);
                await _pedidoAplicacao.Salvar();
                return Created("Get", new { id = pedidoDTO.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _pedidoAplicacao.Deletar(id);
                await _pedidoAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
