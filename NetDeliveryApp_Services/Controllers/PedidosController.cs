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
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult GetPedidos()
        {
            return Ok(_pedidoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetPedido(int id)
        {
            return Ok(_pedidoRepository.Encontrar(id));
        }

        [HttpPut("{id}")]
        public IActionResult PutPedido(int id, [FromBody] Pedido pedido)
        {
            if (_pedidoRepository.Existe(id))
            {
                _pedidoRepository.Editar(pedido);
                _pedidoRepository.Salvar();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult PostPedido(Pedido pedido)
        {
            _pedidoRepository.Adicionar(pedido);
            _pedidoRepository.Salvar();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            if (_pedidoRepository.Existe(id))
            {
                var pedido = _pedidoRepository.Encontrar(id);

                _pedidoRepository.Deletar(pedido);
                _pedidoRepository.Salvar();
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
