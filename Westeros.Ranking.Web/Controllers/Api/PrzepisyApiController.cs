using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Westeros.Ranking.Data.Model;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/PrzepisyApi")]
    public class PrzepisyApiController : Controller
    {
        private readonly StarkDbContext _context;

        public PrzepisyApiController(StarkDbContext context)
        {
            _context = context;
        }

        // GET: api/PrzepisyApi
        [HttpGet]
        public IEnumerable<Przepis> GetPrzepisyOdwiedziny()
        {
            return _context.PrzepisyOdwiedziny;
        }

        // GET: api/PrzepisyApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrzepis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var przepis = await _context.PrzepisyOdwiedziny.SingleOrDefaultAsync(m => m.Id == id);

            if (przepis == null)
            {
                return NotFound();
            }

            return Ok(przepis);
        }

        // PUT: api/PrzepisyApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrzepis([FromRoute] int id, [FromBody] Przepis przepis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != przepis.Id)
            {
                return BadRequest();
            }

            _context.Entry(przepis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrzepisExists(id))
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

        // POST: api/PrzepisyApi
        [HttpPost]
        public async Task<IActionResult> PostPrzepis([FromBody] Przepis przepis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PrzepisyOdwiedziny.Add(przepis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrzepis", new { id = przepis.Id }, przepis);
        }

        // DELETE: api/PrzepisyApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrzepis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var przepis = await _context.PrzepisyOdwiedziny.SingleOrDefaultAsync(m => m.Id == id);
            if (przepis == null)
            {
                return NotFound();
            }

            _context.PrzepisyOdwiedziny.Remove(przepis);
            await _context.SaveChangesAsync();

            return Ok(przepis);
        }

        private bool PrzepisExists(int id)
        {
            return _context.PrzepisyOdwiedziny.Any(e => e.Id == id);
        }
    }
}