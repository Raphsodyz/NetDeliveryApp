using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;

namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAplicacao _clienteAplicacao;

        public ClientesController(IClienteAplicacao clienteAplicacao)
        {
            _clienteAplicacao = clienteAplicacao;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_clienteAplicacao.Listar());
            }
            catch(Exception)
            {
                return BadRequest("Erro ao retornar todos os clientes.");
            }
        }

        [HttpGet("Encontrar/{id}")]
        public IActionResult Encontrar(int id)
        {
            try
            {
                return Ok(_clienteAplicacao.Encontrar(id));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                _clienteAplicacao.Editar(clienteDTO);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("Adicionar")]
        public IActionResult Adicionar(ClienteDTO clientedto)
        {
            try
            {
                _clienteAplicacao.Adicionar(clientedto);
                return Created("Get", new {id = clientedto.Id});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _clienteAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }   
        }
    }
}
