using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Westeros.Ranking.Data.Model;
using Westeros.Ranking.Data.Repositories;
using Westeros.Ranking.Web.Models;

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
            return View(new AddOcenaClass());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOcena(AddOcenaClass a)
        {
            ArrayList Attributes = new ArrayList(a.UrlElements.Substring(1).Split('='));
            Oceny newOcena=new Oceny();
            newOcena.Ocena = a.Ocena;
            newOcena.Data = DateTime.Now;
            newOcena.Nick = a.Nick;
            newOcena.Tekst = a.Tekst;
            
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Oceny.Add(newOcena);
                    _context.SaveChanges();
                }
                else
                return View(a);

                return RedirectToAction(nameof(View));
            }
            catch
            {
                return RedirectToAction(nameof(View));
            }
        }
    }
}