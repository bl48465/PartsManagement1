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
    public class KomentController : ControllerBase
    {


        private readonly MyContext _context;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtservice;

        public KomentController(MyContext context, IUserRepository repository, JwtService jwtService)
        {
            _context = context;
            _repository = repository;
            _jwtservice = jwtService;
        }

        // GET: api/Koment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Komenti>>> GetKomentet()
        {

            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var komentet = await _context.Komentet.ToListAsync();

            return Ok(komentet);
        }

        // GET: api/Koment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Komenti>> GetKomenti(int id)
        {
            var komenti = await _context.Komentet.FindAsync(id);

            if (komenti == null)
            {
                return NotFound();
            }

            return komenti;
        }

        // PUT: api/Koment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKomenti(int id, Komenti komenti)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            if (id != komenti.KomentiID)
            {
                return BadRequest();
            }

            _context.Entry(komenti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomentiExists(id))
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

        // POST: api/Koment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Komenti>> PostKomenti(Komenti komenti)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            Komenti k = new Komenti
            {
                Titulli = komenti.Titulli,
                Mesazhi = komenti.Mesazhi,
                User = user

            };
            

            _context.Komentet.Add(k);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKomenti", new { id = komenti.KomentiID }, komenti);
        }

        // DELETE: api/Koment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Komenti>> DeleteKomenti(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var komenti = await _context.Komentet.FindAsync(id);
            if (komenti == null)
            {
                return NotFound();
            }

            _context.Komentet.Remove(komenti);
            await _context.SaveChangesAsync();

            return komenti;
        }

        private bool KomentiExists(int id)
        {
            return _context.Komentet.Any(e => e.KomentiID == id);
        }
    }
}
