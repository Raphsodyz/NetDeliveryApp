using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
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

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_hamburguerAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os hamburguers.");
            }
        }

        [HttpGet("Encontrar/{id}")]
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

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromBody] HamburguerDTO hamburguerDTO)
        {
            try
            {
                _hamburguerAplicacao.Editar(hamburguerDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        public IActionResult Adicionar(HamburguerDTO hamburguerDTO)
        {
            try
            {
                _hamburguerAplicacao.Adicionar(hamburguerDTO);
                return Created("Get", new { id = hamburguerDTO.Id });
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
