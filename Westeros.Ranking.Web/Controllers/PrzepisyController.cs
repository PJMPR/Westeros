using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web.Controllers
{
    public class PrzepisyController : Controller
    {
        private readonly StarkDbContext _context;

        public PrzepisyController(StarkDbContext c)
        {
            _context = c;
        }

        public IActionResult View()
        {
            return View(_context.PrzepisyOdwiedziny.ToArray());

        }
    }
}