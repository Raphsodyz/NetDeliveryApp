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
    public class HamburguersController : ControllerBase
    {
        private readonly IHamburguerRepository _hamburguerRepository;

        public HamburguersController(IHamburguerRepository hamburguerRepository)
        {
            _hamburguerRepository = hamburguerRepository;
        }

        [HttpGet]
        public IActionResult GetHamburguers()
        {
            return Ok(_hamburguerRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetHamburguer(int id)
        {
            if (_hamburguerRepository.Existe(id))
            {
                return Ok(_hamburguerRepository.Encontrar(id));
            }
            else
                return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult PutHamburguer(int id, [FromBody] Hamburguer hamburguer)
        {
            if (_hamburguerRepository.Existe(id))
            {
                _hamburguerRepository.Editar(hamburguer);
                _hamburguerRepository.Salvar();
                return Ok();
            }
            else
                return NotFound();

        }

        [HttpPost]
        public IActionResult PostHamburguer(Hamburguer hamburguer)
        {
            _hamburguerRepository.Adicionar(hamburguer);
            _hamburguerRepository.Salvar();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHamburguer(int id)
        {
            if (_hamburguerRepository.Existe(id))
            {
                var hamburguer = _hamburguerRepository.Encontrar(id);

                _hamburguerRepository.Deletar(hamburguer);
                _hamburguerRepository.Salvar();
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
