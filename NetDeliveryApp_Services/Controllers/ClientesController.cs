#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(_clienteRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            if (_clienteRepository.Existe(id))
            {
                return Ok(_clienteRepository.Encontrar(id));
            }
            else
                return NotFound();
            
        }

        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, [FromBody] Cliente cliente)
        {
            if (_clienteRepository.Existe(id))
            {
                _clienteRepository.Editar(cliente);
                _clienteRepository.Salvar();
                return Ok();
            }
            else
                return NotFound();
            
        }

        [HttpPost]
        public IActionResult PostCliente(Cliente cliente)
        {
            _clienteRepository.Adicionar(cliente);
            _clienteRepository.Salvar();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            if (_clienteRepository.Existe(id))
            {
                var cliente = _clienteRepository.Encontrar(id);

                _clienteRepository.Deletar(cliente);
                _clienteRepository.Salvar();
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
