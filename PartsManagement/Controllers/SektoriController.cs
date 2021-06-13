using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsManagement.Models;
using Microsoft.AspNetCore.Authorization;
using PartsManagement.Helpers;
using PartsManagement.Data;

namespace PartsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SektoriController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtservice;

        public SektoriController(MyContext context,IUserRepository repository, JwtService jwtService)
        {
            _context = context;
            _repository = repository;
            _jwtservice = jwtService;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sektori>>> GetSektoret()
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var sektoret = await _context.Users.Include(x=>x.Sektoret).Where(a=>a.UserID == user.UserID).ToListAsync();

            return Ok(sektoret);
        }

        // GET: api/Sektori/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sektori>> GetSektori(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var sektori = await _context.Sektoret.Include(s => s.Produktet).Where(p => p.SektoriID == id).ToListAsync();

            if (sektori == null)
            {
                return NotFound();
            }

            return Ok(sektori);
        }

        // PUT: api/Sektori/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSektori(int id, Sektori sektori)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            if (id != sektori.SektoriID)
            {
                return BadRequest();
            }

            _context.Entry(sektori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SektoriExists(id))
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

        // POST: api/Sektori
        [HttpPost]
        public async Task<ActionResult<Sektori>> PostSektori(Sektori sektori)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);

            Sektori s = new Sektori
            {
                Emri = sektori.Emri,
                User = user
            };

            _context.Sektoret.Add(s);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSektori", new { id = sektori.SektoriID }, sektori);
        }

        // DELETE: api/Sektori/5

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sektori>> DeleteSektori(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null) return Unauthorized();

            var sektori = await _context.Sektoret.FindAsync(id);
            if (sektori == null)
            {
                return NotFound();
            }

            _context.Sektoret.Remove(sektori);
            await _context.SaveChangesAsync();

            return sektori;
        }

        private bool SektoriExists(int id)
        {
            return _context.Sektoret.Any(e => e.SektoriID == id);
        }
    }
}
