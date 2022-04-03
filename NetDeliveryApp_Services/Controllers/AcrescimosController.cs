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
    public class AcrescimosController : ControllerBase
    {
        private readonly IAcrescimoRepository _acrescimoRepository;

        public AcrescimosController(IAcrescimoRepository acrescimoRepository)
        {
            _acrescimoRepository = acrescimoRepository;
        }

        [HttpGet]
        public IActionResult GetAcrescimos()
        {
            return Ok(_acrescimoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetAcrescimo(int id)
        {
            if (_acrescimoRepository.Existe(id))
            {
                return Ok(_acrescimoRepository.Encontrar(id));
            }
            else
                return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult PutAcrescimo(int id, [FromBody] Acrescimo acrescimo)
        {
            if (_acrescimoRepository.Existe(id))
            {
                _acrescimoRepository.Editar(acrescimo);
                _acrescimoRepository.Salvar();
                return Ok();
            }
            else
                return NotFound();

        }

        [HttpPost]
        public IActionResult PostCliente(Acrescimo acrescimo)
        {
            _acrescimoRepository.Adicionar(acrescimo);
            _acrescimoRepository.Salvar();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            if (_acrescimoRepository.Existe(id))
            {
                var acrescimo = _acrescimoRepository.Encontrar(id);

                _acrescimoRepository.Deletar(acrescimo);
                _acrescimoRepository.Salvar();
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
