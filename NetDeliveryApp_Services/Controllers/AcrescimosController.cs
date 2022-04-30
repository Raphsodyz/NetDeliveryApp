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
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _acrescimoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os acrescimos.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Encontrar(int id)
        {
            try
            {
                return Ok(await _acrescimoAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar([FromBody] AcrescimoDTO acrescimoDTO)
        {
            try
            {
                await _acrescimoAplicacao.Editar(acrescimoDTO);
                await _acrescimoAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Adicionar(AcrescimoDTO acrescimoDTO)
        {
            try
            {
                _acrescimoAplicacao.Adicionar(acrescimoDTO);
                await _acrescimoAplicacao.Salvar();
                return Created("Get", new { id = acrescimoDTO.Id });
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
                await _acrescimoAplicacao.Deletar(id);
                await _acrescimoAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
