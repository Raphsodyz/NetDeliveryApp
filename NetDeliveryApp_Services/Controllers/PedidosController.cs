using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_pedidoAplicacao.Listar());
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
                return Ok(_pedidoAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Pedido pedido)
        {
            try
            {
                _pedidoAplicacao.Editar(pedido);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Adicionar(Pedido pedido)
        {
            try
            {
                _pedidoAplicacao.Adicionar(pedido);
                return Created("Get", new { id = pedido.Id });
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
