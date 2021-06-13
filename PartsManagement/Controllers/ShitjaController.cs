using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsManagement.Models;
using PartsManagement.Data;
using PartsManagement.Dtos;
using PartsManagement.Helpers;

namespace PartsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShitjaController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtservice;

        public ShitjaController(MyContext context,IUserRepository repository, JwtService jwtService)
        {
            _context = context;
            _repository = repository;
            _jwtservice = jwtService;
        }

        // GET: api/Shitja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shitja>>> GetShitjet()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var usr = _repository.GetById(userId);
            if (usr == null) return Unauthorized();

            var shitjet = await _context.Shitjet.Where(u => u.User == usr).ToListAsync();
            return Ok(shitjet);
        }

        // GET: api/Shitja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shitja>> GetShitja(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var usr = _repository.GetById(userId);
            if (usr == null) return Unauthorized();

            var shitja = await _context.Shitjet.Where(a=>a.User == usr && a.ShitjaID == id).ToListAsync();

            if (shitja == null)
            {
                return NotFound();
            }

            return Ok(shitja);
        }

        // PUT: api/Shitja/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShitja(int id, Shitja shitja)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var usr = _repository.GetById(userId);
            if (usr == null) return Unauthorized();

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
        [HttpPost("{produktiID}")]
        public async Task<ActionResult<Shitja>> PostShitja(ShitjaDTO dto,int produktiID)
        { 
            var productToDelete = await _context.Produktet.FindAsync(produktiID);

            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);

            if(user == null)
            {
                return Unauthorized(new
                {
                    message="Kyquni së pari"
                });
            }

            var shitja = new Shitja
            {
                Emri = dto.Emri,
                User = user,
                Qmimi = dto.Qmimi * dto.Sasia,
                Sasia = dto.Sasia ,
                OEnumber = dto.OEnumber,
            };

            
            if (dto.Sasia > productToDelete.Sasia)
            {
                return BadRequest(new
                {
                    message = "Nuk ke sasi të mjaftueshme"
                });
            }

            if (productToDelete.Sasia == 0)
            {
                _context.Produktet.Remove(productToDelete);
            }
            else
            {
                productToDelete.Sasia -= dto.Sasia;

                _context.Shitjet.Add(shitja);
                await _context.SaveChangesAsync();
            }
                return CreatedAtAction("GetShitja", new { id = shitja.ShitjaID }, shitja);
        }

        // DELETE: api/Shitja/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shitja>> DeleteShitja(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var usr = _repository.GetById(userId);
            if (usr == null) return Unauthorized();

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
