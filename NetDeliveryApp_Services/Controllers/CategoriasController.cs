using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;


namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaAplicacao _categoriaAplicacao;

        public CategoriasController(ICategoriaAplicacao categoriaAplicacao)
        {
            _categoriaAplicacao = categoriaAplicacao;
        }

        [HttpGet("Listar")]
        [AllowAnonymous]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _categoriaAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos as categorias.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Encontrar(int id)
        {
            try
            {
                var categoria = await _categoriaAplicacao.Encontrar(id);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                await _categoriaAplicacao.Editar(categoriaDTO);
                await _categoriaAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Adicionar(CategoriaDTO categoriaDTO)
        {
            try
            {
                _categoriaAplicacao.Adicionar(categoriaDTO);
                await _categoriaAplicacao.Salvar();
                return Created("Adicionar", new { Adicionado = categoriaDTO.Nome });
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
                await _categoriaAplicacao.Deletar(id);
                await _categoriaAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
