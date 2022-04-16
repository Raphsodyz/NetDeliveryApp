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
        public IActionResult Listar()
        {
            try
            {
                return Ok(_categoriaAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos as categorias.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        [AllowAnonymous]
        public IActionResult Encontrar(int id)
        {
            try
            {
                return Ok(_categoriaAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                _categoriaAplicacao.Editar(categoriaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        public IActionResult Adicionar(CategoriaDTO categoriaDTO)
        {
            try
            {
                _categoriaAplicacao.Adicionar(categoriaDTO);
                return Created("Get", new { id = categoriaDTO.Id });
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
                _categoriaAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
