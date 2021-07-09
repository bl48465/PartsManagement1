using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsManagement.Models;

namespace PartsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KerkesaController : ControllerBase
    {
        private readonly MyContext _context;

        public KerkesaController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Kerkesa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kerkesa>>> GetKerkesat()
        {
            return await _context.Kerkesat.ToListAsync();
        }

        // GET: api/Kerkesa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kerkesa>> GetKerkesa(int id)
        {
            var kerkesa = await _context.Kerkesat.FindAsync(id);

            if (kerkesa == null)
            {
                return NotFound();
            }

            return kerkesa;
        }

        // PUT: api/Kerkesa/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKerkesa(int id, Kerkesa kerkesa)
        {
            if (id != kerkesa.KekresaID)
            {
                return BadRequest();
            }

            _context.Entry(kerkesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KerkesaExists(id))
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

        // POST: api/Kerkesa
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kerkesa>> PostKerkesa(Kerkesa kerkesa)
        {
            _context.Kerkesat.Add(kerkesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKerkesa", new { id = kerkesa.KekresaID }, kerkesa);
        }

        // DELETE: api/Kerkesa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kerkesa>> DeleteKerkesa(int id)
        {
            var kerkesa = await _context.Kerkesat.FindAsync(id);
            if (kerkesa == null)
            {
                return NotFound();
            }

            _context.Kerkesat.Remove(kerkesa);
            await _context.SaveChangesAsync();

            return kerkesa;
        }

        private bool KerkesaExists(int id)
        {
            return _context.Kerkesat.Any(e => e.KekresaID == id);
        }
    }
}
