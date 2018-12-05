using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web.Controllers
{
    public class KomentarzeController : Controller
    {
        private readonly StarkDbContext _context;

        public KomentarzeController(StarkDbContext c)
        {
            _context = c;
        }

        public IActionResult View()
        {
            return View(_context.Komentarz.ToList());
        }
    }
}