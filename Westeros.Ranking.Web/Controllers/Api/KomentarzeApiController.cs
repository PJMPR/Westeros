using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Westeros.Ranking.Data.Model;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/KomentarzeApi")]
    public class KomentarzeApiController : Controller
    {
        private readonly StarkDbContext _context;

        public KomentarzeApiController(StarkDbContext context)
        {
            _context = context;
        }

        // GET: api/KomentarzeApi
        [HttpGet]
        public IEnumerable<Komentarz> GetKomentarz()
        {
            return _context.Komentarz;
        }

        // GET: api/KomentarzeApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKomentarz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var komentarz = await _context.Komentarz.SingleOrDefaultAsync(m => m.id == id);

            if (komentarz == null)
            {
                return NotFound();
            }

            return Ok(komentarz);
        }

        // PUT: api/KomentarzeApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKomentarz([FromRoute] int id, [FromBody] Komentarz komentarz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != komentarz.id)
            {
                return BadRequest();
            }

            _context.Entry(komentarz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomentarzExists(id))
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

        // POST: api/KomentarzeApi
        [HttpPost]
        public async Task<IActionResult> PostKomentarz([FromBody] Komentarz komentarz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Komentarz.Add(komentarz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKomentarz", new { id = komentarz.id }, komentarz);
        }

        // DELETE: api/KomentarzeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKomentarz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var komentarz = await _context.Komentarz.SingleOrDefaultAsync(m => m.id == id);
            if (komentarz == null)
            {
                return NotFound();
            }

            _context.Komentarz.Remove(komentarz);
            await _context.SaveChangesAsync();

            return Ok(komentarz);
        }

        private bool KomentarzExists(int id)
        {
            return _context.Komentarz.Any(e => e.id == id);
        }
    }
}