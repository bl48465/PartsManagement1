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
    public class SektoriController : ControllerBase
    {
        private readonly MyContext _context;

        public SektoriController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Sektori
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sektori>>> GetSektoret()
        {

            var sektoret =  await _context.Sektoret.Include(s => s.Produktet).ToListAsync();

            return Ok(sektoret);
        }

        // GET: api/Sektori/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sektori>> GetSektori(int id)
        {
            var sektori = await _context.Sektoret.FindAsync(id);

            if (sektori == null)
            {
                return NotFound();
            }

            return sektori;
        }

        // PUT: api/Sektori/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSektori(int id, Sektori sektori)
        {
            if (id != sektori.SektoriID)
            {
                return BadRequest();
            }

            _context.Entry(sektori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SektoriExists(id))
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

        // POST: api/Sektori
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<ActionResult<Sektori>> PostSektori(int id,Sektori sektori)
        {
            sektori.UserId = id;
            _context.Sektoret.Add(sektori);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSektori", new { id = sektori.SektoriID }, sektori);
        }

        // DELETE: api/Sektori/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sektori>> DeleteSektori(int id)
        {
            var sektori = await _context.Sektoret.FindAsync(id);
            if (sektori == null)
            {
                return NotFound();
            }

            _context.Sektoret.Remove(sektori);
            await _context.SaveChangesAsync();

            return sektori;
        }

        private bool SektoriExists(int id)
        {
            return _context.Sektoret.Any(e => e.SektoriID == id);
        }
    }
}
