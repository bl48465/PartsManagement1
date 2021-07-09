using AutoMapper;
using PartsManagement.Dtos;
using PartsManagement.Models;
using PartsManagement.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using PartsManagement.IRepository;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PartsManagement.Controllers
{   
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly MyContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthManager _authManager;

        public AdminController(UserManager<User> userManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager,
            MyContext context,
            SignInManager<User> signInManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _context = context;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(){
            var userat = await _context.Users.Where(a => !(a.Kompania.Equals("BeliTECH"))).ToListAsync();
            return Ok(userat);
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUsers(string id, [FromBody] UserDTO userDTO)
        {
            
            if (!ModelState.IsValid || id.Length < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUsers)}");
                return BadRequest(ModelState);
            }

            var përdoruesi = _context.Users.Where(a => a.Id.Equals(id));

            var p = përdoruesi.FirstOrDefault(); 

            if (p == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUsers)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, p);
            p.UserName = p.Email;
            _context.Users.Update(p);
            await _context.SaveChangesAsync();

            return Ok("Përdoruesi u përditësua me sukses!");

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id.Length < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteUser)}");
                return BadRequest();
            }

            var përdoruesi = _context.Users.Where(a => a.Id.Equals(id));

            var p = përdoruesi.FirstOrDefault(); 

            if (p == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteUser)}");
                return BadRequest("Submitted data is invalid");
            }

             _context.Users.Remove(p);
            await _context.SaveChangesAsync();

            return Ok($"Përdoruesi {p.Emri} {p.Mbiemri} u fshi me sukses!");

        }
    }
}