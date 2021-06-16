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
    public class DetajetHyreseController : ControllerBase
    {
        private readonly MyContext _context;

        public DetajetHyreseController(MyContext context)
        {
            _context = context;
        }

        // GET: api/DetajetHyrese
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetajetHyrese>>> GetDetajetHyrese()
        {
            return await _context.DetajetHyrese.Include(p=>p.Fatura).Include(p=>p.Produkti).ToListAsync();
        }

        // GET: api/DetajetHyrese/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetajetHyrese>> GetDetajetHyrese(int id)
        {
            var detajetHyrese = await _context.DetajetHyrese.FindAsync(id);

            if (detajetHyrese == null)
            {
                return NotFound();
            }

            return detajetHyrese;
        }

        // PUT: api/DetajetHyrese/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetajetHyrese(int id, DetajetHyrese detajetHyrese)
        {
            if (id != detajetHyrese.DetajetHyreseID)
            {
                return BadRequest();
            }

            _context.Entry(detajetHyrese).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetajetHyreseExists(id))
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

        // POST: api/DetajetHyrese
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetajetHyrese>> PostDetajetHyrese(DetajetHyrese detajetHyrese)
        {
            _context.DetajetHyrese.Add(detajetHyrese);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetajetHyrese", new { id = detajetHyrese.DetajetHyreseID }, detajetHyrese);
        }

        // DELETE: api/DetajetHyrese/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetajetHyrese>> DeleteDetajetHyrese(int id)
        {
            var detajetHyrese = await _context.DetajetHyrese.FindAsync(id);
            if (detajetHyrese == null)
            {
                return NotFound();
            }

            _context.DetajetHyrese.Remove(detajetHyrese);
            await _context.SaveChangesAsync();

            return detajetHyrese;
        }

        private bool DetajetHyreseExists(int id)
        {
            return _context.DetajetHyrese.Any(e => e.DetajetHyreseID == id);
        }
    }
}
