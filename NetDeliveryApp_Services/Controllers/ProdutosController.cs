using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;

namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAplicacao _produtoAplicacao;

        public ProdutosController(IProdutoAplicacao produtoAplicacao)
        {
            _produtoAplicacao = produtoAplicacao;
        }

        [HttpGet("Listar")]
        [AllowAnonymous]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_produtoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os produtos.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        [AllowAnonymous]
        public IActionResult Encontrar(int id)
        {
            try
            {
                return Ok(_produtoAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                _produtoAplicacao.Editar(produtoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        public IActionResult Adicionar(ProdutoDTO produtoDTO)
        {
            try
            {
                _produtoAplicacao.Adicionar(produtoDTO);
                return Created("Get", new { id = produtoDTO.Id });
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
                _produtoAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
