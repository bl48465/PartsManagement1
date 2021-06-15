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
    public class PorosiaController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtservice;

        public PorosiaController(MyContext context, IUserRepository repository, JwtService jwtService)
        {
            _context = context;
            _repository = repository;
            _jwtservice = jwtService;
        }
        //Metoda 
        // GET: api/Porosia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Porosia>>> GetPorosite()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var porosia = await _context.Users.Include(x => x.Porosite).Where(a => a.UserID == user.UserID).ToListAsync();

            return Ok(porosia);
        }

        // GET: api/Porosia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Porosia>> GetPorosia(int id)
        {

            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var porosia = await _context.Porosite.Include(s => s.PorosiaID).Where(p => p.PorosiaID == id).ToListAsync();


            if (porosia == null)
            {
                return NotFound();
            }

            return Ok(porosia);
        }

        // PUT: api/Porosia/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPorosia(int id, Porosia porosia)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

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
        public async Task<ActionResult<Porosia>> PostPorosia(Porosia porosia)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            Porosia s = new Porosia
            {
                Emri = porosia.Emri,
                Sasia = porosia.Sasia,

            };

            _context.Porosite.Add(s);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPorosia", new { id = porosia.PorosiaID }, porosia);
        }

        // DELETE: api/Porosia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Porosia>> DeletePorosia(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

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
