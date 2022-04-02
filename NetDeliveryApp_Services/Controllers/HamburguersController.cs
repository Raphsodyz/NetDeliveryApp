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
    public class HamburguersController : ControllerBase
    {
        private readonly NetDeliveryAppContext _context;

        public HamburguersController(NetDeliveryAppContext context)
        {
            _context = context;
        }

        // GET: api/Hamburguers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hamburguer>>> GetHamburguers()
        {
            return await _context.Hamburguers.ToListAsync();
        }

        // GET: api/Hamburguers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hamburguer>> GetHamburguer(int id)
        {
            var hamburguer = await _context.Hamburguers.FindAsync(id);

            if (hamburguer == null)
            {
                return NotFound();
            }

            return hamburguer;
        }

        // PUT: api/Hamburguers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHamburguer(int id, Hamburguer hamburguer)
        {
            if (id != hamburguer.Id)
            {
                return BadRequest();
            }

            _context.Entry(hamburguer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HamburguerExists(id))
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

        // POST: api/Hamburguers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hamburguer>> PostHamburguer(Hamburguer hamburguer)
        {
            _context.Hamburguers.Add(hamburguer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHamburguer", new { id = hamburguer.Id }, hamburguer);
        }

        // DELETE: api/Hamburguers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHamburguer(int id)
        {
            var hamburguer = await _context.Hamburguers.FindAsync(id);
            if (hamburguer == null)
            {
                return NotFound();
            }

            _context.Hamburguers.Remove(hamburguer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HamburguerExists(int id)
        {
            return _context.Hamburguers.Any(e => e.Id == id);
        }
    }
}
