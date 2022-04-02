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

namespace NetDeliveryAppServicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcrescimosController : ControllerBase
    {
        private readonly NetDeliveryAppContext _context;

        public AcrescimosController(NetDeliveryAppContext context)
        {
            _context = context;
        }

        // GET: api/Acrescimos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acrescimo>>> GetAcrescimos()
        {
            return await _context.Acrescimos.ToListAsync();
        }

        // GET: api/Acrescimos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acrescimo>> GetAcrescimo(int id)
        {
            var acrescimo = await _context.Acrescimos.FindAsync(id);

            if (acrescimo == null)
            {
                return NotFound();
            }

            return acrescimo;
        }

        // PUT: api/Acrescimos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcrescimo(int id, Acrescimo acrescimo)
        {
            if (id != acrescimo.Id)
            {
                return BadRequest();
            }

            _context.Entry(acrescimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcrescimoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Acrescimos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acrescimo>> PostAcrescimo(Acrescimo acrescimo)
        {
            _context.Acrescimos.Add(acrescimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcrescimo", new { id = acrescimo.Id }, acrescimo);
        }

        // DELETE: api/Acrescimos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcrescimo(int id)
        {
            var acrescimo = await _context.Acrescimos.FindAsync(id);
            if (acrescimo == null)
            {
                return NotFound();
            }

            _context.Acrescimos.Remove(acrescimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcrescimoExists(int id)
        {
            return _context.Acrescimos.Any(e => e.Id == id);
        }
    }
}
