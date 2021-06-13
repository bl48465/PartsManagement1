using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsManagement.Models;
using PartsManagement.Helpers;
using PartsManagement.Data;

namespace PartsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktiController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtservice;

        public ProduktiController(MyContext context, IUserRepository repository, JwtService jwtService)
        {
            _context = context;
            _repository = repository;
            _jwtservice = jwtService;
        }
        
        // GET: api/Produkti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produkti>>> GetProduktet()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var produktet = await _context.Sektoret.Include(x => x.Produktet).Where(u => u.User == user).ToListAsync();

            return Ok(produktet);
        }

        // GET: api/Produkti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produkti>> GetProdukti(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var produkti = await _context.Produktet.FindAsync(id);

            if (produkti == null)
            {
                return NotFound();
            }

            return produkti;
        }

        // PUT: api/Produkti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukti(int id, Produkti produkti)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

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

        // POST: api/Produkti
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<ActionResult<Produkti>> PostProdukti(Produkti produkti, int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var prod = new Produkti
            {
                Emri = produkti.Emri,
                Qmimi = produkti.Qmimi,
                Sasia = produkti.Sasia,
                OEnumber = produkti.OEnumber,
                SektoriID = id
            };

            _context.Produktet.Add(prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdukti", new { id = produkti.ProduktiID }, produkti);
        }

        // DELETE: api/Produkti/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produkti>> DeleteProdukti(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

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
