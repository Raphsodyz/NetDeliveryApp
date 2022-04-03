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
    public class BebidasController : ControllerBase
    {
        private readonly IBebidaRepository _bebidaRepository;

        public BebidasController(IBebidaRepository bebidaRepository)
        {
            _bebidaRepository = bebidaRepository;
        }

        [HttpGet]
        public IActionResult GetBebidas()
        {
            return Ok(_bebidaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetBebida(int id)
        {
            if (_bebidaRepository.Existe(id))
            {
                return Ok(_bebidaRepository.Encontrar(id));
            }
            else
                return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult PutBebida(int id, [FromBody] Bebida bebida)
        {
            if (_bebidaRepository.Existe(id))
            {
                _bebidaRepository.Editar(bebida);
                _bebidaRepository.Salvar();
                return Ok();
            }
            else
                return NotFound();

        }

        [HttpPost]
        public IActionResult PostBebida(Bebida bebida)
        {
            _bebidaRepository.Adicionar(bebida);
            _bebidaRepository.Salvar();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBebida(int id)
        {
            if (_bebidaRepository.Existe(id))
            {
                var bebida = _bebidaRepository.Encontrar(id);

                _bebidaRepository.Deletar(bebida);
                _bebidaRepository.Salvar();
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
