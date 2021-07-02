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

<<<<<<< HEAD
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateShitja([FromBody] CreateFaturaOUTDTO fatura, int prodId)
=======
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
>>>>>>> parent of bf1934f (Backend Refactor Completed - Final ?)
        {
            if (id != shitja.ShitjaID)
            {
                return BadRequest();
            }

            _context.Entry(shitja).State = EntityState.Modified;

            try
            {
<<<<<<< HEAD
                var puntori = _context.Users.Where(a => a.Id.Equals(userId));
                var p = puntori.FirstOrDefault();

                var shefi = _context.Users.Where(a => a.Id == p.ShefiId);
                var sh = shefi.FirstOrDefault();

                var fati = new CreateFaturaOUTDTO
                {
                    ProduktiId = prodId
                };

                var faturap =  _mapper.Map<FaturaOUT>(fati);

                var sell = new CreateShitjaDTO
                {
                    UserId = p.ShefiId,
                    FaturaId = faturap.FaturaId
                };

                var sellp = _mapper.Map<Shitja>(sell);


                //var updatestock = _context.FaturatIN.Where(x => x.ProduktiId == prodId);
                //var u = updatestock.FirstOrDefault();

                //u.Sasia -= sasia;

                //if(u.Sasia < 0) { return BadRequest("Nuk ke sasi"); }

                //_context.FaturatIN.Update(u);
                _context.FaturatOUT.Add(faturap);
                _context.Shitjet.Add(sellp);
=======
>>>>>>> parent of bf1934f (Backend Refactor Completed - Final ?)
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
<<<<<<< HEAD
                var fati = new CreateFaturaOUTDTO
                {
                    ProduktiId = prodId
                };

                var faturap = _mapper.Map<FaturaOUT>(fati);

                //var sell = new CreateShitjaDTO
                //{
                //    UserId = userId,
                //    FaturaId = faturap.FaturaId
                //};

                //var sellp = _mapper.Map<Shitja>(sell);

                //var updatestock = _context.FaturatIN.Where(x => x.ProduktiId == prodId);
                //var u = updatestock.FirstOrDefault();

                //u.Sasia -= sasia; 

                //if (u.Sasia < 0) { return BadRequest("Nuk ke sasi"); }

                //_context.FaturatIN.Update(u);
                _context.FaturatOUT.Add(faturap);
                //_context.Shitjet.Add(sellp);
                await _context.SaveChangesAsync();

            }

            return Ok($"Produkti {pr.Emri} u shit me sukses");

=======
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
>>>>>>> parent of bf1934f (Backend Refactor Completed - Final ?)
        }

        // POST: api/Shitja
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shitja>> PostShitja(Shitja shitja)
        {
            _context.Shitjet.Add(shitja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShitja", new { id = shitja.ShitjaID }, shitja);
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
