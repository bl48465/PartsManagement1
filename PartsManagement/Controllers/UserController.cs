using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace PartsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyContext _context;

        public UserController(MyContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet("register")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
   
        [HttpPost("register")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    throw new ArgumentException(
                            $"Emaili {user.Email} është në përdorim.");
                }

                PasswordHasher<User> hasher = new PasswordHasher<User>();
                user.Password = hasher.HashPassword(user, user.Password);

                var newUser = _context.Users.Add(user).Entity;
                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32("UserId", newUser.UserId);
            }
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, User user)
        {
            user.UserId = id;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.Users.Any(e => e.UserId == id)))
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin userlogin)
        {
            if (ModelState.IsValid)
            {
                var UserInDB = await _context.Users.FirstOrDefaultAsync(u => u.Email == userlogin.Email);

                if (UserInDB == null)
                {
                    throw new ArgumentException(
                           $"Useri nuk ekziston");
                }

                var hasher = new PasswordHasher<UserLogin>();
                var result = hasher.VerifyHashedPassword(userlogin, UserInDB.Password, userlogin.Password);
                
                if (result == 0)
                {
                    throw new ArgumentException(
                           $"Fjalëkalmi i dhënë gabim");
                }

                HttpContext.Session.SetInt32("UserId", UserInDB.UserId);
                
                //redirect to dashboard
                throw new ArgumentException(
                           $"Jeni kyqur me sukses..");
            }

            //redirect to login + error
            throw new ArgumentException(
                           $"Te dhenat jo valide!");
        }

        [HttpPost("admin")]
        public async Task<IActionResult> Admin(AdminLogin admlogin)
        {
            if (ModelState.IsValid)
            {
                var AdminInDB = await _context.Admins.FirstOrDefaultAsync(u => u.Username == admlogin.Username);

                if (AdminInDB == null)
                {
                    throw new ArgumentException(
                         $"Te dhenat jo valide!");
                }

                if (AdminInDB.Password == admlogin.Password)
                {
                    HttpContext.Session.SetInt32("AdminId", AdminInDB.AdminId);

                    //Redirekto ne dashboard!
                    throw new ArgumentException(
                         $"Sukses!");
                }
            }
            throw new ArgumentException(
                         $"Te dhenat jo valide!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAdmin(int id, AdminLogin admin)
        {
            admin.AdminId= id;

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.Admins.Any(e => e.AdminId == id)))
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

        [HttpGet("logout")]
        public IActionResult Logout()
        {

            //redirekto ne login
            HttpContext.Session.Clear();
            throw new ArgumentException(
                         $"Login Again!");
        }

        // DELETE: api/User/5
        /* [HttpDelete("{id}")]
         public async Task<ActionResult<User>> DeleteUser(int id)
         {
             var user = await _context.Users.FindAsync(id);
             if (user == null)
             {
                 return NotFound();
             }

             _context.Users.Remove(user);
             await _context.SaveChangesAsync();

             return user;
         }*/
    }
}
