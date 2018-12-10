using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web.Controllers
{
    public class OcenaController : Controller
    {
        private readonly StarkDbContext _context;

        public OcenaController(StarkDbContext c)
        {
            _context = c;
        }
        public IActionResult View()
        {
            return View(_context.Oceny.ToArray());
        }
    }
}