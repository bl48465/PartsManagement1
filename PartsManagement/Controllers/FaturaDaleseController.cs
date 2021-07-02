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
//     public class FaturaDaleseController : ControllerBase
//     {
//         private readonly MyContext _context;

//         public FaturaDaleseController(MyContext context)
//         {
//             _context = context;
//         }

//         // GET: api/FaturaDalese
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<FaturaDalese>>> GetFaturaDalese()
//         {
//             return await _context.FaturaDalese.ToListAsync();
//         }

//         // GET: api/FaturaDalese/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<FaturaDalese>> GetFaturaDalese(int id)
//         {
//             var faturaDalese = await _context.FaturaDalese.FindAsync(id);

//             if (faturaDalese == null)
//             {
//                 return NotFound();
//             }

//             return faturaDalese;
//         }

//         // PUT: api/FaturaDalese/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutFaturaDalese(int id, FaturaDalese faturaDalese)
//         {
//             if (id != faturaDalese.FaturaDaleseID)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(faturaDalese).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!FaturaDaleseExists(id))
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

//         // POST: api/FaturaDalese
//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//         [HttpPost]
//         public async Task<ActionResult<FaturaDalese>> PostFaturaDalese(FaturaDalese faturaDalese)
//         {
//             _context.FaturaDalese.Add(faturaDalese);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetFaturaDalese", new { id = faturaDalese.FaturaDaleseID }, faturaDalese);
//         }

//         // DELETE: api/FaturaDalese/5
//         [HttpDelete("{id}")]
//         public async Task<ActionResult<FaturaDalese>> DeleteFaturaDalese(int id)
//         {
//             var faturaDalese = await _context.FaturaDalese.FindAsync(id);
//             if (faturaDalese == null)
//             {
//                 return NotFound();
//             }

//             _context.FaturaDalese.Remove(faturaDalese);
//             await _context.SaveChangesAsync();

//             return faturaDalese;
//         }

//         private bool FaturaDaleseExists(int id)
//         {
//             return _context.FaturaDalese.Any(e => e.FaturaDaleseID == id);
//         }
//     }
// }
