// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using PartsManagement.Models;

// namespace PartsManagement.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class FaturaHyreseController : ControllerBase
//     {
//         private readonly MyContext _context;

//         public FaturaHyreseController(MyContext context)
//         {
//             _context = context;
//         }

//         // GET: api/FaturaHyrese
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<FaturaHyrese>>> GetFaturaHyrese()
//         {
//             return await _context.FaturaHyrese.ToListAsync();
//         }

//         // GET: api/FaturaHyrese/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<FaturaHyrese>> GetFaturaHyrese(int id)
//         {
//             var faturaHyrese = await _context.FaturaHyrese.FindAsync(id);

//             if (faturaHyrese == null)
//             {
//                 return NotFound();
//             }

//             return faturaHyrese;
//         }

//         // PUT: api/FaturaHyrese/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutFaturaHyrese(int id, FaturaHyrese faturaHyrese)
//         {
//             if (id != faturaHyrese.FaturaHyreseID)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(faturaHyrese).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!FaturaHyreseExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/FaturaHyrese
//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//         [HttpPost]
//         public async Task<ActionResult<FaturaHyrese>> PostFaturaHyrese(FaturaHyrese faturaHyrese)
//         {
//             _context.FaturaHyrese.Add(faturaHyrese);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetFaturaHyrese", new { id = faturaHyrese.FaturaHyreseID }, faturaHyrese);
//         }

//         // DELETE: api/FaturaHyrese/5
//         [HttpDelete("{id}")]
//         public async Task<ActionResult<FaturaHyrese>> DeleteFaturaHyrese(int id)
//         {
//             var faturaHyrese = await _context.FaturaHyrese.FindAsync(id);
//             if (faturaHyrese == null)
//             {
//                 return NotFound();
//             }

//             _context.FaturaHyrese.Remove(faturaHyrese);
//             await _context.SaveChangesAsync();

//             return faturaHyrese;
//         }

//         private bool FaturaHyreseExists(int id)
//         {
//             return _context.FaturaHyrese.Any(e => e.FaturaHyreseID == id);
//         }
//     }
// }
