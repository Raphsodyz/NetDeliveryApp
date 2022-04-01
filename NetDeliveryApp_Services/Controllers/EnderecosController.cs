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
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecosController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        public IActionResult GetEnderecos()
        {
            return Ok(_enderecoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetEndereco(int id)
        {
            if (_enderecoRepository.Existe(id))
            {
                return Ok(_enderecoRepository.Encontrar(id));
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutEndereco(int id, [FromBody] Endereco endereco)
        {
            if (_enderecoRepository.Existe(id))
            {
                _enderecoRepository.Editar(endereco);
                _enderecoRepository.Salvar();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult PostEndereco(Endereco endereco)
        {
            _enderecoRepository.Adicionar(endereco);
            _enderecoRepository.Salvar();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            if (_enderecoRepository.Existe(id))
            {
                var endereco = _enderecoRepository.Encontrar(id);

                _enderecoRepository.Deletar(endereco);
                _enderecoRepository.Salvar();
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
