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
    public class KomentController : ControllerBase
    {
        private readonly MyContext _context;

        public KomentController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Koment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Komenti>>> GetKomentet()
        {
            return await _context.Komentet.ToListAsync();
        }

        // GET: api/Koment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Komenti>> GetKomenti(int id)
        {
            var komenti = await _context.Komentet.FindAsync(id);

            if (komenti == null)
            {
                return NotFound();
            }

            return komenti;
        }

        // PUT: api/Koment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKomenti(int id, Komenti komenti)
        {
            if (id != komenti.KomentiID)
            {
                return BadRequest();
            }

            _context.Entry(komenti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomentiExists(id))
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

        // POST: api/Koment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<ActionResult<Komenti>> PostKomenti(Komenti komenti, int id)
        {
            komenti.UserID = id;
            _context.Komentet.Add(komenti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKomenti", new { id = komenti.KomentiID }, komenti);
        }

        // DELETE: api/Koment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Komenti>> DeleteKomenti(int id)
        {
            var komenti = await _context.Komentet.FindAsync(id);
            if (komenti == null)
            {
                return NotFound();
            }

            _context.Komentet.Remove(komenti);
            await _context.SaveChangesAsync();

            return komenti;
        }

        private bool KomentiExists(int id)
        {
            return _context.Komentet.Any(e => e.KomentiID == id);
        }
    }
}
