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
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _produtoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os produtos.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Encontrar(int id)
        {
            try
            {
                return Ok(await _produtoAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar(ProdutoDTO produtoDTO)
        {
            try
            {
                await _produtoAplicacao.Editar(produtoDTO);
                await _produtoAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Adicionar(ProdutoDTO produtoDTO)
        {
            try
            {
                _produtoAplicacao.Adicionar(produtoDTO);
                await _produtoAplicacao.Salvar();
                return Created("Get", new { id = produtoDTO.Id });
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
                await _produtoAplicacao.Deletar(id);
                await _produtoAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
