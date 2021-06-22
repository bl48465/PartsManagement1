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
    public class MarkaController : ControllerBase
    {
        private readonly MyContext _context;

        public MarkaController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Markas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marka>>> GetMarka()
        {
            return await _context.Marka.ToListAsync();
        }

        // GET: api/Markas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marka>> GetMarka(int id)
        {
            var marka = await _context.Marka.FindAsync(id);

            if (marka == null)
            {
                return NotFound();
            }

            return marka;
        }

        // PUT: api/Markas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarka(int id, Marka marka)
        {
            if (id != marka.MarkaID)
            {
                return BadRequest();
            }

            _context.Entry(marka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkaExists(id))
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

        // POST: api/Markas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Marka>> PostMarka(Marka marka)
        {
            _context.Marka.Add(marka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarka", new { id = marka.MarkaID }, marka);
        }

        // DELETE: api/Markas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Marka>> DeleteMarka(int id)
        {
            var marka = await _context.Marka.FindAsync(id);
            if (marka == null)
            {
                return NotFound();
            }

            _context.Marka.Remove(marka);
            await _context.SaveChangesAsync();

            return marka;
        }

        private bool MarkaExists(int id)
        {
            return _context.Marka.Any(e => e.MarkaID == id);
        }
    }
}
