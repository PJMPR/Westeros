using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Westeros.Ranking.Data.Model;
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

        public IActionResult AddOcena()
        {
            return View(new Oceny());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOcena(Oceny ocena)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Oceny.Add(ocena);
                    _context.SaveChanges();
                }
                else
                    return View(ocena);

                return RedirectToAction(nameof(View));
            }
            catch
            {
                return RedirectToAction(nameof(View));
            }
        }
    }
}