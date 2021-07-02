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
    public class DetajetDaleseController : ControllerBase
    {
        private readonly MyContext _context;

        public DetajetDaleseController(MyContext context)
        {
            _context = context;
        }

        // GET: api/DetajetDalese
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetajetDalese>>> GetDetajetDalese()
        {
            return await _context.DetajetDalese.Include(p=>p.Prod).Include(p=>p.FaturimiDales).ToListAsync();
        }

        // GET: api/DetajetDalese/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetajetDalese>> GetDetajetDalese(int id)
        {
            var detajetDalese = await _context.DetajetDalese.FindAsync(id);

            if (detajetDalese == null)
            {
                return NotFound();
            }

            return detajetDalese;
        }

        // PUT: api/DetajetDalese/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetajetDalese(int id, DetajetDalese detajetDalese)
        {
            if (id != detajetDalese.DetajetDaleseID)
            {
                return BadRequest();
            }

            _context.Entry(detajetDalese).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetajetDaleseExists(id))
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

        // POST: api/DetajetDalese
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetajetDalese>> PostDetajetDalese(DetajetDalese detajetDalese)
        {
            _context.DetajetDalese.Add(detajetDalese);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetajetDalese", new { id = detajetDalese.DetajetDaleseID }, detajetDalese);
        }

        // DELETE: api/DetajetDalese/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetajetDalese>> DeleteDetajetDalese(int id)
        {
            var detajetDalese = await _context.DetajetDalese.FindAsync(id);
            if (detajetDalese == null)
            {
                return NotFound();
            }

            _context.DetajetDalese.Remove(detajetDalese);
            await _context.SaveChangesAsync();

            return detajetDalese;
        }

        private bool DetajetDaleseExists(int id)
        {
            return _context.DetajetDalese.Any(e => e.DetajetDaleseID == id);
        }
    }
}
