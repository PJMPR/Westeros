using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Westeros.Ranking.Data.Model;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web
{
    [Produces("application/json")]
    [Route("api/DietaApi")]
    public class DietaApiController : Controller
    {
        private readonly StarkDbContext _context;

        public DietaApiController(StarkDbContext context)
        {
            _context = context;
        }

        // GET: api/DietaApi
        [HttpGet]
        public IEnumerable<Dieta> GetDietyOdwiedziny()
        {
            return _context.DietyOdwiedziny;
        }

        // GET: api/DietaApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDieta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dieta = await _context.DietyOdwiedziny.SingleOrDefaultAsync(m => m.Id == id);

            if (dieta == null)
            {
                return NotFound();
            }

            return Ok(dieta);
        }

        // PUT: api/DietaApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDieta([FromRoute] int id, [FromBody] Dieta dieta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dieta.Id)
            {
                return BadRequest();
            }

            _context.Entry(dieta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietaExists(id))
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

        // POST: api/DietaApi
        [HttpPost]
        public async Task<IActionResult> PostDieta([FromBody] Dieta dieta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DietyOdwiedziny.Add(dieta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDieta", new { id = dieta.Id }, dieta);
        }

        // DELETE: api/DietaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDieta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dieta = await _context.DietyOdwiedziny.SingleOrDefaultAsync(m => m.Id == id);
            if (dieta == null)
            {
                return NotFound();
            }

            _context.DietyOdwiedziny.Remove(dieta);
            await _context.SaveChangesAsync();

            return Ok(dieta);
        }

        private bool DietaExists(int id)
        {
            return _context.DietyOdwiedziny.Any(e => e.Id == id);
        }
    }
}