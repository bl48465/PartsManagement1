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
    public class ShtetiController : ControllerBase
    {
        private readonly MyContext _context;

        public ShtetiController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Shteti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shteti>>> GetShteti()
        {
            return await _context.Shteti.ToListAsync();
        }

        // GET: api/Shteti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shteti>> GetShteti(int id)
        {
            var shteti = await _context.Shteti.FindAsync(id);

            if (shteti == null)
            {
                return NotFound();
            }

            return shteti;
        }

        // PUT: api/Shteti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShteti(int id, Shteti shteti)
        {
            if (id != shteti.ShtetiID)
            {
                return BadRequest();
            }

            _context.Entry(shteti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShtetiExists(id))
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

        // POST: api/Shteti
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shteti>> PostShteti(Shteti shteti)
        {
            _context.Shteti.Add(shteti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShteti", new { id = shteti.ShtetiID }, shteti);
        }

        // DELETE: api/Shteti/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shteti>> DeleteShteti(int id)
        {
            var shteti = await _context.Shteti.FindAsync(id);
            if (shteti == null)
            {
                return NotFound();
            }

            _context.Shteti.Remove(shteti);
            await _context.SaveChangesAsync();

            return shteti;
        }

        private bool ShtetiExists(int id)
        {
            return _context.Shteti.Any(e => e.ShtetiID == id);
        }
    }
}
