using Microsoft.AspNetCore.Mvc;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Aplicacao;

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

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Cliente cliente)
        {
            try
            {
                _clienteAplicacao.Editar(cliente);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Adicionar(Cliente cliente)
        {
            try
            {
                _clienteAplicacao.Adicionar(cliente);
                return Created("Get", new {id = cliente.Id});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
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
