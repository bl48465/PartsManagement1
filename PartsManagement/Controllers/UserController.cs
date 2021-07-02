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
    [Authorize(Roles="User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly MyContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthManager _authManager;

        public UserController(UserManager<User> userManager,
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
        [HttpGet("puntoret")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllPuntort(){

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var puntoret = await _userManager.Users.Where(a => a.ShefiId == userId).ToListAsync();

            return Ok(puntoret);
        }

        [HttpPost]
        [Route("register/puntor")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                var shefiId = _context.Users.Where(a=>a.Id == userId); 

                var shefi = shefiId.FirstOrDefault(); 

                var user = _mapper.Map<User>(userDTO);

                user.ShefiId = userId;
                user.UserName = userDTO.Email;
                user.Kompania = shefi.Kompania;
                userDTO.Roles = new string[] {"Puntor"};
               
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePuntori(string id, [FromBody] UserDTO userDTO)
        {
            
            if (!ModelState.IsValid || id.Length < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdatePuntori)}");
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var puntori = _context.Users.Where(a => a.Id.Equals(id) && a.ShefiId.Equals(userId));

            var p = puntori.FirstOrDefault(); 

            if (p == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdatePuntori)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, p);
            p.UserName = p.Email;
            _context.Users.Update(p);
            await _context.SaveChangesAsync();

            return Ok("Puntori u përditësua me sukses!");

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePuntori(string id)
        {
            if (id.Length < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeletePuntori)}");
                return BadRequest();
            }


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var puntori = _context.Users.Where(a => a.Id.Equals(id) && a.ShefiId.Equals(userId));

            var p = puntori.FirstOrDefault(); 

            if (p == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeletePuntori)}");
                return BadRequest("Submitted data is invalid");
            }

             _context.Users.Remove(p);
            await _context.SaveChangesAsync();

            return Ok($"Puntori {p.Emri} {p.Mbiemri} u fshi me sukses!");

        }
    }
}