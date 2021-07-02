using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using PartsManagement.Helpers;
using PartsManagement.Data;

namespace PartsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtservice;

        public UserController(MyContext context, IUserRepository repository, JwtService jwtService)
        {
            _context = context;
            _repository = repository;
            _jwtservice = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            // var jwt = Request.Cookies["jwt"];
            // var token = _jwtservice.Verify(jwt);
            // int userId = int.Parse(token.Issuer);
            // var user = _repository.GetById(userId);
            // if (user == null) return Unauthorized();

            var users = await _context.Users.ToListAsync();
                // .Include(p => p.Komentet)
                // .Include(p=>p.Shitjet)
                // .Include(p => p.Porosite)
                // .Include(p=>p.Vendbanimi)
                // .Include(p=>p.Vendbanimi.Shteti)
                // .Include(s => s.Sektoret)
                // .ThenInclude(p => p.Produktet)
                // .ThenInclude(p => p.DetajetHyrese)
                // .ThenInclude(p => p.Fatura).ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            if (user == null || user.Roli != 0) return Unauthorized();

            var usr = await _context.Users.Include(s => s.Sektoret).Where(u => u.UserID == id).ToListAsync(); 

            if (usr == null)
            {
                return NotFound(new { 
                message = "Përdoruesi nuk u gjet."
                });
            }
            return Ok(user);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var usr = _repository.GetById(userId);
            if (usr == null || usr.Roli != 0) return Unauthorized();

            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

 
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var token = _jwtservice.Verify(jwt);
            int userId = int.Parse(token.Issuer);
            var usr = _repository.GetById(userId);
            if (usr == null || usr.Roli != 0) return Unauthorized();

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {

            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
