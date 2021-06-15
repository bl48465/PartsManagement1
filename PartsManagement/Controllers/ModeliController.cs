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
    public class ModeliController : ControllerBase
    {
        private readonly MyContext _context;

        public ModeliController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Modelis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modeli>>> GetModeli()
        {
            return await _context.Modeli.ToListAsync();
        }

        // GET: api/Modelis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modeli>> GetModeli(int id)
        {
            var modeli = await _context.Modeli.FindAsync(id);

            if (modeli == null)
            {
                return NotFound();
            }

            return modeli;
        }

        // PUT: api/Modelis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModeli(int id, Modeli modeli)
        {
            if (id != modeli.ModeliID)
            {
                return BadRequest();
            }

            _context.Entry(modeli).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeliExists(id))
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

        // POST: api/Modelis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Modeli>> PostModeli(Modeli modeli)
        {
            _context.Modeli.Add(modeli);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModeli", new { id = modeli.ModeliID }, modeli);
        }

        // DELETE: api/Modelis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Modeli>> DeleteModeli(int id)
        {
            var modeli = await _context.Modeli.FindAsync(id);
            if (modeli == null)
            {
                return NotFound();
            }

            _context.Modeli.Remove(modeli);
            await _context.SaveChangesAsync();

            return modeli;
        }

        private bool ModeliExists(int id)
        {
            return _context.Modeli.Any(e => e.ModeliID == id);
        }
    }
}
