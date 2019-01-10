using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            var IsClassOk = false;
            List<string> Attributes = null;
            if (a.UrlElements.Length > 0)
                Attributes = new List<string>(a.UrlElements.Substring(1).Split('='));
            else
                return RedirectToAction(nameof(View));
            var newOcena = new Oceny();
            newOcena.Ocena = a.Ocena;
            newOcena.Data = DateTime.Now;
            newOcena.Nick = a.Nick;
            newOcena.Tekst = a.Tekst;
            if (Attributes.Contains("resourceId") && Attributes.Contains("resourceName"))
            {
                newOcena.resourceId =
                    Convert.ToInt32(Attributes[Attributes.FindIndex(x => x.Equals("resourceId")) + 1]);
                newOcena.resourceName = Attributes[Attributes.FindIndex(x => x.Equals("resourceName")) + 1];
                IsClassOk = true;
            }

            try
            {
                if (ModelState.IsValid && IsClassOk)
                {
                    _context.Oceny.Add(newOcena);
                    _context.SaveChanges();
                }
                else
                {
                    return View(a);
                }

                return RedirectToAction(nameof(View));
            }
            catch
            {
                return RedirectToAction(nameof(View));
            }
        }
    }
}