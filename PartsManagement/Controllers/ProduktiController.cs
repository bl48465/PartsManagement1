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
    public class ProduktiController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly MyContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authManager;

        public ProduktiController(UserManager<User> userManager,
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


        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetProduktet()
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (role.Equals("Puntor"))
            {
                var puntori = _context.Users.Where(a => a.Id.Equals(userId));
                var p = puntori.FirstOrDefault();
                var produkti = await _context.Produktet.Where(x => x.Sektori.UserId == p.ShefiId).ToListAsync();
                if (produkti == null) { return NotFound($"Produktet nuk u gjetën!"); }
                return Ok(produkti);
            }
            else
            {
                var produkteteuserit = await _unitOfWork.Produktet.GetAll(a => a.Sektori.UserId == userId);
                if (produkteteuserit == null) { return NotFound($"Produktet nuk u gjetën!"); }
                return Ok(produkteteuserit);
            }
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSektor([FromBody] CreateProduktiDTO produktiDTO)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateSektor)}");
                return BadRequest(ModelState);
            }
  
            if (role.Equals("Puntor"))
            {
                var puntori = _context.Users.Where(a => a.Id.Equals(userId));
                var p = puntori.FirstOrDefault();

                var shefi = _context.Users.Where(a => a.Id == p.ShefiId);
                var sh = shefi.FirstOrDefault();

                var checkExist = await _unitOfWork.Produktet.Get(a => a.Sektori.SektoriId == produktiDTO.SektoriId && a.Emri.Equals(produktiDTO.Emri));
                if (checkExist != null) { return BadRequest($"Produkti ekziston!"); }
               
                var produkti = _mapper.Map<Produkti>(produktiDTO);
                await _unitOfWork.Produktet.Insert(produkti);
                await _unitOfWork.Save();
                
                return Ok($"Produkti { produkti.Emri } u shtua me sukses");
            }
            else
            {
                var checkExist = await _unitOfWork.Produktet.Get(a => a.Sektori.UserId == userId);
                if (checkExist != null) { return BadRequest($"Produkti ekziston!"); }

                var produkti = _mapper.Map<Produkti>(produktiDTO);
                await _unitOfWork.Produktet.Insert(produkti);
                await _unitOfWork.Save();
                return Ok($"Produkti { produkti.Emri } u shtua me sukses");
            }

        }

        [HttpPost("stoku")]
        [Authorize(Roles ="User")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStoku([FromBody] CreateFaturaINDTO faturaINDTO)
        {
         
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateStoku)}");
                return BadRequest(ModelState);
            }

            faturaINDTO.UserId = userId;
            var fatura = _mapper.Map<FaturaIN>(faturaINDTO);
            _context.FaturatIN.Add(fatura);
            await _context.SaveChangesAsync();
            return Ok($"Fatura u shtua me sukses");

        }

        [Authorize(Roles = "User")]
        [HttpGet("stoku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetStokun()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var stoku = await _context.Produktet.Include(p => p.Faturat).ToListAsync();
            return Ok(stoku);
        }

        //GET: api/Produkti/5
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProdukti(int id)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (role.Equals("Puntor"))
            {

                var puntori = _context.Users.Where(a => a.Id.Equals(userId));
                var p = puntori.FirstOrDefault();
                var produkti = await _context.Produktet.Where(x => x.Sektori.UserId == p.ShefiId && x.ProduktiId == id).ToListAsync();
                
                if (produkti.Count < 1) { return NotFound($"Produkti me ID {id} nuk u gjet!"); }
                return Ok(produkti);
            }
            else
            {

                var produktiuserit = await _context.Produktet.Where(a => a.Sektori.UserId == userId && a.ProduktiId == id).ToListAsync();
              
                if (produktiuserit.Count < 1) { return NotFound($"Produkti me ID {id} nuk u gjet!"); }
                return Ok(produktiuserit);

            }
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProdukti(int id, [FromBody] UpdateProduktiDTO produktiDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateSektoriDTO)}");
                return BadRequest(ModelState);
            }

            var role = User.FindFirstValue(ClaimTypes.Role);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (role.Equals("Puntor"))
            {
                var puntori = _context.Users.Where(a => a.Id.Equals(userId));
                var p = puntori.FirstOrDefault();
                var produkti = await _unitOfWork.Produktet.Get(a => a.Sektori.UserId == p.ShefiId && a.ProduktiId == id);

                if (produkti == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateProdukti)}");
                    return BadRequest("Submitted data is invalid");
                }

                produktiDTO.SektoriId = produkti.SektoriId;
                _mapper.Map(produktiDTO, produkti);
                _unitOfWork.Produktet.Update(produkti);
                await _unitOfWork.Save();
                return Ok(produkti);
            }
            else
            {
                var produkti = await _unitOfWork.Produktet.Get(a => a.Sektori.UserId == userId && a.ProduktiId == id);

                if (produkti == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateProdukti)}");
                    return BadRequest("Submitted data is invalid");
                }


                produktiDTO.SektoriId = produkti.SektoriId;
                _mapper.Map(produktiDTO, produkti);
                _unitOfWork.Produktet.Update(produkti);
                await _unitOfWork.Save();


                return Ok(produkti + "Produkti u përditësua me sukses!");
            }

        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSektori(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteSektori)}");
                return BadRequest();
            }

            var role = User.FindFirstValue(ClaimTypes.Role);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (role.Equals("Puntor"))
            {
                var puntori = _context.Users.Where(a => a.Id.Equals(userId));
                var p = puntori.FirstOrDefault();

                var produkti = await _unitOfWork.Produktet.Get(a => a.Sektori.UserId == p.ShefiId && a.ProduktiId == id);

                if (produkti == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateProdukti)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Produktet.Delete(produkti.ProduktiId);
                await _unitOfWork.Save();
                return Ok($"Produkti {produkti.Emri} u fshij me sukses! ");
            }
            else
            {
                var produkti = await _unitOfWork.Produktet.Get(a => a.Sektori.UserId == userId && a.ProduktiId == id);

                if (produkti == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateProdukti)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Produktet.Delete(produkti.ProduktiId);
                await _unitOfWork.Save();
                return Ok($"Produkti {produkti.Emri} u fshij me sukses! ");

            }
        }
    }
}