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
    public class FurnitorisController : ControllerBase
    {
        private readonly MyContext _context;

        public FurnitorisController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Furnitoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Furnitori>>> GetFurnitoret()
        {
            return await _context.Furnitoret.ToListAsync();
        }

        // GET: api/Furnitoris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Furnitori>> GetFurnitori(int id)
        {
            var furnitori = await _context.Furnitoret.FindAsync(id);

            if (furnitori == null)
            {
                return NotFound();
            }

            return furnitori;
        }

        // PUT: api/Furnitoris/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFurnitori(int id, Furnitori furnitori)
        {
            if (id != furnitori.FurnitoriID)
            {
                return BadRequest();
            }

            _context.Entry(furnitori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnitoriExists(id))
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

        // POST: api/Furnitoris
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Furnitori>> PostFurnitori(Furnitori furnitori)
        {
            _context.Furnitoret.Add(furnitori);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFurnitori", new { id = furnitori.FurnitoriID }, furnitori);
        }

        // DELETE: api/Furnitoris/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Furnitori>> DeleteFurnitori(int id)
        {
            var furnitori = await _context.Furnitoret.FindAsync(id);
            if (furnitori == null)
            {
                return NotFound();
            }

            _context.Furnitoret.Remove(furnitori);
            await _context.SaveChangesAsync();

            return furnitori;
        }

        private bool FurnitoriExists(int id)
        {
            return _context.Furnitoret.Any(e => e.FurnitoriID == id);
        }
    }
}
