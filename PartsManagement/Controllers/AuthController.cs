using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartsManagement.Data;
using PartsManagement.Dtos;
using PartsManagement.Models;
using PartsManagement.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace PartsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtservice;

        public AuthController(IUserRepository repository,JwtService jwtService)
        {
            _repository = repository;
            _jwtservice = jwtService;
        }

    [HttpPost("register")]
    public IActionResult Register(RegisterDTO dto)
        {
            var user = new User
            {
                Emri = dto.Emri,
                Mbiemri = dto.Mbiemri,
                Kompania = dto.Kompania,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Konfirmimi = BCrypt.Net.BCrypt.HashPassword(dto.Konfirmimi),
                VendbanimiID = dto.VendbanimiID
            };

            var check = _repository.GetByEmail(dto.Email);

            if (check == null) return Created("success", _repository.Create(user));
            else
            {
                return BadRequest(new { message = "Përdoruesi tashmë ekziston" });
            }
        }

    [HttpPost("login")]
    public IActionResult Login(LoginDTO dto)
    {
            var user = _repository.GetByEmail(dto.Email);
            
            if(user == null) return BadRequest(new { message = "Të dhënat gabim" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Të dhënat gabim" });
            }

            var jwt = _jwtservice.generate(user.UserID);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "U kyqët me sukses"
            });
    }

    [HttpGet("user")]
    public IActionResult GetCurrentUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtservice.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }
            catch(Exception)
            {
                return Unauthorized();
            }
        }
    
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "Dalja nga profili me sukses"
            });
        }

}
}
