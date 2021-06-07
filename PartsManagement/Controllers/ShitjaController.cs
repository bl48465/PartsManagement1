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
    public class ShitjaController : ControllerBase
    {
        private readonly MyContext _context;

        public ShitjaController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Shitja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shitja>>> GetShitjet()
        {
            return await _context.Shitjet.ToListAsync();
        }

        // GET: api/Shitja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shitja>> GetShitja(int id)
        {
            var shitja = await _context.Shitjet.FindAsync(id);

            if (shitja == null)
            {
                return NotFound();
            }

            return shitja;
        }

        // PUT: api/Shitja/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShitja(int id, Shitja shitja)
        {
            if (id != shitja.ShitjaID)
            {
                return BadRequest();
            }


            _context.Entry(shitja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShitjaExists(id))
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

        // POST: api/Shitja
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{userid}/{id}/{quantity}")]
        public async Task<ActionResult<Shitja>> PostShitja(Shitja shitja,int id,int userid, int quantity)
        {
            shitja.UserID = userid;

            var productToDelete = await _context.Produktet.FindAsync(id);

            if (quantity > productToDelete.Sasia)
            {   
                throw new ArgumentException(
                       $"Nuk ke sasi te mjaftueshme");
            }
            else
            {

                shitja.Emri = productToDelete.Emri;
                shitja.Qmimi = productToDelete.Qmimi * quantity;
                shitja.Sasia = quantity;
                shitja.OEnumber = productToDelete.OEnumber;


               
                if (productToDelete.Sasia == 0)
                {
                    _context.Produktet.Remove(productToDelete);
                }
                else
                {
                    productToDelete.Sasia -= quantity;
                }

                _context.Shitjet.Add(shitja);
                //_context.Produktet.Add(productToDelete);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetShitja", new { id = shitja.ShitjaID }, shitja);
            }
        }

        // DELETE: api/Shitja/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shitja>> DeleteShitja(int id)
        {
            var shitja = await _context.Shitjet.FindAsync(id);
            if (shitja == null)
            {
                return NotFound();
            }

            _context.Shitjet.Remove(shitja);
            await _context.SaveChangesAsync();

            return shitja;
        }

        private bool ShitjaExists(int id)
        {
            return _context.Shitjet.Any(e => e.ShitjaID == id);
        }
    }
}
