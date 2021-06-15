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
    public class ProduktiController : ControllerBase
    {
        private readonly MyContext _context;

        public ProduktiController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Produktis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produkti>>> GetProduktet()
        {
            return await _context.Produktet.ToListAsync();
        }

        // GET: api/Produktis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produkti>> GetProdukti(int id)
        {
            var produkti = await _context.Produktet.FindAsync(id);

            if (produkti == null)
            {
                return NotFound();
            }

            return produkti;
        }

        // PUT: api/Produktis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukti(int id, Produkti produkti)
        {
            if (id != produkti.ProduktiID)
            {
                return BadRequest();
            }

            _context.Entry(produkti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktiExists(id))
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

        // POST: api/Produktis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Produkti>> PostProdukti(Produkti produkti)
        {
            _context.Produktet.Add(produkti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdukti", new { id = produkti.ProduktiID }, produkti);
        }

        // DELETE: api/Produktis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produkti>> DeleteProdukti(int id)
        {
            var produkti = await _context.Produktet.FindAsync(id);
            if (produkti == null)
            {
                return NotFound();
            }

            _context.Produktet.Remove(produkti);
            await _context.SaveChangesAsync();

            return produkti;
        }

        private bool ProduktiExists(int id)
        {
            return _context.Produktet.Any(e => e.ProduktiID == id);
        }
    }
}
