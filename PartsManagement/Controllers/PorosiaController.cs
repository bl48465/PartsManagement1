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
    public class PorosiaController : ControllerBase
    {
        private readonly MyContext _context;

        public PorosiaController(MyContext context)
        {
            _context = context;
        }
        //Metoda 
        // GET: api/Porosia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Porosia>>> GetPorosite()
        {
            return await _context.Porosite.ToListAsync();
        }

        // GET: api/Porosia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Porosia>> GetPorosia(int id)
        {
            var porosia = await _context.Porosite.FindAsync(id);

            if (porosia == null)
            {
                return NotFound();
            }

            return porosia;
        }

        // PUT: api/Porosia/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPorosia(int id, Porosia porosia)
        {
            if (id != porosia.PorosiaID)
            {
                return BadRequest();
            }

            _context.Entry(porosia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PorosiaExists(id))
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

        // POST: api/Porosia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<ActionResult<Porosia>> PostPorosia(Porosia porosia,int id)
        {
            porosia.UserID = id;
            _context.Porosite.Add(porosia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPorosia", new { id = porosia.PorosiaID }, porosia);
        }

        // DELETE: api/Porosia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Porosia>> DeletePorosia(int id)
        {
            var porosia = await _context.Porosite.FindAsync(id);
            if (porosia == null)
            {
                return NotFound();
            }

            _context.Porosite.Remove(porosia);
            await _context.SaveChangesAsync();

            return porosia;
        }

        private bool PorosiaExists(int id)
        {
            return _context.Porosite.Any(e => e.PorosiaID == id);
        }
    }
}
