using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_enderecoAplicacao.Listar());
            }
            catch (Exception)
            {
                return BadRequest("Erro ao retornar todos os clientes.");
            }
        }

        [HttpGet("{id}")]
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

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Endereco endereco)
        {
            try
            {
                _enderecoAplicacao.Editar(endereco);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Adicionar(Endereco endereco)
        {
            try
            {
                _enderecoAplicacao.Adicionar(endereco);
                return Created("Get", new { id = endereco.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
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
