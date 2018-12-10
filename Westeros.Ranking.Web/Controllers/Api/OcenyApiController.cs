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
    [Route("api/OcenyApi")]
    public class OcenyApiController : Controller
    {
        private readonly StarkDbContext _context;

        public OcenyApiController(StarkDbContext context)
        {
            _context = context;
        }

        // GET: api/OcenyApi
        [HttpGet]
        public IEnumerable<Oceny> GetOceny()
        {
            return _context.Oceny;
        }

        // GET: api/OcenyApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOceny([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oceny = await _context.Oceny.SingleOrDefaultAsync(m => m.id == id);

            if (oceny == null)
            {
                return NotFound();
            }

            return Ok(oceny);
        }

        // PUT: api/OcenyApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOceny([FromRoute] int id, [FromBody] Oceny oceny)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oceny.id)
            {
                return BadRequest();
            }

            _context.Entry(oceny).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcenyExists(id))
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

        // POST: api/OcenyApi
        [HttpPost]
        public async Task<IActionResult> PostOceny([FromBody] Oceny oceny)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Oceny.Add(oceny);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOceny", new { id = oceny.id }, oceny);
        }

        // DELETE: api/OcenyApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOceny([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oceny = await _context.Oceny.SingleOrDefaultAsync(m => m.id == id);
            if (oceny == null)
            {
                return NotFound();
            }

            _context.Oceny.Remove(oceny);
            await _context.SaveChangesAsync();

            return Ok(oceny);
        }

        private bool OcenyExists(int id)
        {
            return _context.Oceny.Any(e => e.id == id);
        }
    }
}