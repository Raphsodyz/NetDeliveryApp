using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;


namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoAplicacao _enderecoAplicacao;

        public EnderecosController(IEnderecoAplicacao enderecoAplicacao)
        {
            _enderecoAplicacao = enderecoAplicacao;
        }

        [HttpGet("Listar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_enderecoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os enderecos.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        public IActionResult Encontrar(int id)
        {
            try
            {
                return Ok(_enderecoAplicacao.Encontrar(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromBody] EnderecoDTO enderecoDTO)
        {
            try
            {
                _enderecoAplicacao.Editar(enderecoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Adicionar(EnderecoDTO enderecoDTO)
        {
            try
            {
                _enderecoAplicacao.Adicionar(enderecoDTO);
                return Created("Get", new { id = enderecoDTO.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _enderecoAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
