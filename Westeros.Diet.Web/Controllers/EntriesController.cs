using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Westeros.Diet.Data.Model;
using Westeros.Diet.Data.Repositories;
using Westeros.Diet.Web.Models;

namespace Westeros.Diet.Web.Controllers
{
    public class EntriesController : Controller
    {
        private readonly DietDbContext _context;

        public EntriesController(DietDbContext context)
        {
            _context = context;
        }

        // GET: Entries
        public ActionResult Index()
        {
            HttpContext.Session.SetInt32("Id", 1);
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(UserProfileController.Index), "UserProfile");
            }

            int id = HttpContext.Session.GetInt32("Id").GetValueOrDefault();
            var entry = _context.Entries.Where(x => x.UserProfileId == id)
                .Include(i => i.EntryIngredients)
                .ThenInclude(i => i.Ingredient)
                .Include(r => r.EntryRecipes)
                .ThenInclude(r => r.Recipe)
                .ThenInclude(r=>r.RecipeIngredients)
                .ThenInclude(r=>r.Ingredient);
            var eModel = new List<EntriesModel>();

            foreach (var e in entry)
            {
                eModel.Add(contextToModel(e));
            }

            return View(eModel);
        }

        private static EntriesModel contextToModel(Entry e)
        {
            return new EntriesModel
            {
                Id = e.Id,
                Date = e.Date,
                Weight = e.Weight,
                UserProfileId = e.UserProfileId,
                UserProfile = e.UserProfile,
                EntryIngredients = e.EntryIngredients,
                EntryRecipes = e.EntryRecipes
            };
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Weight")] Entry entry)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(UserProfileController.SignIn));
            }

            if (ModelState.IsValid)
            {
                entry.UserProfileId = (int)HttpContext.Session.GetInt32("Id");
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Weight,UserProfileId")] Entry entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                    .Include(i => i.EntryIngredients)
                    .ThenInclude(i => i.Ingredient)
                    .Include(r => r.EntryRecipes)
                    .ThenInclude(r => r.Recipe)
                    .ThenInclude(r => r.RecipeIngredients)
                    .ThenInclude(r => r.Ingredient)
                    .SingleOrDefaultAsync(x => x.Id == id);

            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }


        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.Id == id);
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
