using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;


namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcrescimosController : ControllerBase
    {
        private readonly IAcrescimoAplicacao _acrescimoAplicacao;

        public AcrescimosController(IAcrescimoAplicacao acrescimoAplicacao)
        {
            _acrescimoAplicacao = acrescimoAplicacao;
        }

        [HttpGet("Listar")]
        [AllowAnonymous]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_acrescimoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os acrescimos.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        [AllowAnonymous]
        public IActionResult Encontrar(int id)
        {
            try
            {
                return Ok(_acrescimoAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromBody] AcrescimoDTO acrescimoDTO)
        {
            try
            {
                _acrescimoAplicacao.Editar(acrescimoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        [AllowAnonymous]
        public IActionResult Adicionar(AcrescimoDTO acrescimoDTO)
        {
            try
            {
                _acrescimoAplicacao.Adicionar(acrescimoDTO);
                return Created("Get", new { id = acrescimoDTO.Id });
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
                _acrescimoAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
