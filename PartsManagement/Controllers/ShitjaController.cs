using AutoMapper;
using System.Net.Http;
using PartsManagement.Models;
using PartsManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartsManagement.IRepository;
using PartsManagement.Dtos;


namespace PartsManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShitjaController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly MyContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authManager;

        public ShitjaController(UserManager<User> userManager,
             ILogger<AccountController> logger,
             IMapper mapper,
             IAuthManager authManager,
             MyContext context,
             IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "User")]
        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetShitjet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var shitjet = await _context.Shitjet.Where(s => s.UserId.Equals(userId)).ToListAsync();
            return Ok(shitjet);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateShitja([FromBody] CreateFaturaOUTDTO fatura, int prodId)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateShitja)}");
                return BadRequest(ModelState);
            }

            var produkti = _context.Produktet.Where(a => a.ProduktiId == prodId);
            var pr = produkti.FirstOrDefault();

            if (role.Equals("Puntor"))
            {
                var puntori = _context.Users.Where(a => a.Id.Equals(userId));
                var p = puntori.FirstOrDefault();

                var shefi = _context.Users.Where(a => a.Id == p.ShefiId);
                var sh = shefi.FirstOrDefault();

                var fati = new CreateFaturaOUTDTO
                {
                    ProduktiId = prodId
                };

                var faturap =  _mapper.Map<FaturaOUT>(fati);

                var sell = new CreateShitjaDTO
                {
                    UserId = p.ShefiId,
                    FaturaId = faturap.FaturaId
                };

                var sellp = _mapper.Map<Shitja>(sell);


                //var updatestock = _context.FaturatIN.Where(x => x.ProduktiId == prodId);
                //var u = updatestock.FirstOrDefault();

                //u.Sasia -= sasia;

                //if(u.Sasia < 0) { return BadRequest("Nuk ke sasi"); }

                //_context.FaturatIN.Update(u);
                _context.FaturatOUT.Add(faturap);
                _context.Shitjet.Add(sellp);
                await _context.SaveChangesAsync();
            }
            else
            {
                var fati = new CreateFaturaOUTDTO
                {
                    ProduktiId = prodId
                };

                var faturap = _mapper.Map<FaturaOUT>(fati);

                //var sell = new CreateShitjaDTO
                //{
                //    UserId = userId,
                //    FaturaId = faturap.FaturaId
                //};

                //var sellp = _mapper.Map<Shitja>(sell);

                //var updatestock = _context.FaturatIN.Where(x => x.ProduktiId == prodId);
                //var u = updatestock.FirstOrDefault();

                //u.Sasia -= sasia; 

                //if (u.Sasia < 0) { return BadRequest("Nuk ke sasi"); }

                //_context.FaturatIN.Update(u);
                _context.FaturatOUT.Add(faturap);
                //_context.Shitjet.Add(sellp);
                await _context.SaveChangesAsync();

            }

            return Ok($"Produkti {pr.Emri} u shit me sukses");

        }

        [Authorize(Roles = "User")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteShitja(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteShitja)}");
                return BadRequest();
            }


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shitja =  _context.Shitjet.Where(a => a.UserId == userId && a.ShitjaId == id);
            var sh = shitja.FirstOrDefault();

            if (shitja == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteShitja)}");
                return BadRequest("Submitted data is invalid");
            }

            _context.Shitjet.Remove(sh);
            await _context.SaveChangesAsync();

            return Ok($"Shitja me ID {sh.ShitjaId} u fshij me sukses! ");

        }
    }
}