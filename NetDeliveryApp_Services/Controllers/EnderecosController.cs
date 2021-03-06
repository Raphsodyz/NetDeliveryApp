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
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _enderecoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os enderecos.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        public async Task<IActionResult> Encontrar(int id)
        {
            try
            {
                var endereco = await _enderecoAplicacao.Encontrar(id);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Editar([FromBody] EnderecoDTO enderecoDTO)
        {
            try
            {
                await _enderecoAplicacao.Editar(enderecoDTO);
                await _enderecoAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Adicionar(EnderecoDTO enderecoDTO)
        {
            try
            {
                _enderecoAplicacao.Adicionar(enderecoDTO);
                await _enderecoAplicacao.Salvar();
                return Created("Adicionar", new { Adicionado = enderecoDTO.Id });
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
                await _enderecoAplicacao.Deletar(id);
                await _enderecoAplicacao.Salvar();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
