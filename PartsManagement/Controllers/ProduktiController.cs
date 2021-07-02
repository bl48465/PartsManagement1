using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsManagement.Models;

namespace PartsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktiController : ControllerBase
    {
        private readonly MyContext _context;

        public ProduktiController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Produktis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produkti>>> GetProduktet()
        {
            return await _context.Produktet
                .Include(p=>p.Sektori)
                .Include(p=>p.DetajetHyrese)
                .Include(p=>p.DetajetDalese)
                .ToListAsync();
        }

<<<<<<< HEAD
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
=======
        // GET: api/Produktis/5
>>>>>>> parent of bf1934f (Backend Refactor Completed - Final ?)
        [HttpGet("{id}")]
        public async Task<ActionResult<Produkti>> GetProdukti(int id)
        {
            var produkti = await _context.Produktet.FindAsync(id);

            if (produkti == null)
            {
                return NotFound();
            }

            return produkti;
        }

        // PUT: api/Produktis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukti(int id, Produkti produkti)
        {
            if (id != produkti.ProduktiID)
            {
                return BadRequest();
            }

            _context.Entry(produkti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktiExists(id))
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

        // POST: api/Produktis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Produkti>> PostProdukti(Produkti produkti)
        {
            _context.Produktet.Add(produkti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdukti", new { id = produkti.ProduktiID }, produkti);
        }

        // DELETE: api/Produktis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produkti>> DeleteProdukti(int id)
        {
            var produkti = await _context.Produktet.FindAsync(id);
            if (produkti == null)
            {
                return NotFound();
            }

            _context.Produktet.Remove(produkti);
            await _context.SaveChangesAsync();

            return produkti;
        }

        private bool ProduktiExists(int id)
        {
            return _context.Produktet.Any(e => e.ProduktiID == id);
        }
    }
}
