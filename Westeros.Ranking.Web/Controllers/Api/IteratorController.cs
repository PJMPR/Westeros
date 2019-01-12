using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Westeros.Ranking.Data.Model;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Iterator")]
    public class IteratorController : Controller
    {
        private readonly StarkDbContext _context;

        public IteratorController(StarkDbContext context)
        {
            _context = context;
        }
        // Post: api/Iterator
        [HttpPost]
        public async Task<IActionResult> PostDieta([FromBody]Iterator request)
        {
            if (string.Equals("dieta",request.resourcename))
            {
                var updateDieta = _context.DietyOdwiedziny.Where(s => s.DietaId == request.id).FirstOrDefault();
                if (updateDieta.Id==request.id)
                {
                    updateDieta.IloscOdwiedzin += 1;
                    _context.DietyOdwiedziny.Update(updateDieta);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest("bad id");
            }
            if(string.Equals("przepis",request.resourcename))
            {
                var updateDieta = _context.PrzepisyOdwiedziny.Where(s => s.PrzepisId==request.id).FirstOrDefault();
                if (updateDieta.Id == request.id)
                {
                    updateDieta.IloscOdwiedzin += 1;
                    _context.PrzepisyOdwiedziny.Update(updateDieta);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest("bad id");
            }
            else
            {
                return NoContent();
            }
            
        }

    }
}