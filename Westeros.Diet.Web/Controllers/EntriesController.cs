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
using Westeros.Diet.Data;

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
            var entry = _context.Entries.AsNoTracking().Where(x => x.UserProfileId == id)
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
                EntryIngredients = e.EntryIngredients.ToList(),
                EntryRecipes = e.EntryRecipes.ToList()
            };
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries.AsNoTracking()
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

        // GET: Entries/Create
        public async Task<IActionResult> Create()
        {
            var ing = await _context.Ingredients.ToListAsync();
            var rec = await _context.Recipes.Include(r => r.RecipeIngredients).ThenInclude(r => r.Ingredient).ToListAsync();
            var model = new EntriesCreateModel
            {
                Ingredients = ing,
                Recipes = rec,
                UserProfileId = HttpContext.Session.GetInt32("Id").GetValueOrDefault()
            };

            foreach (var item in ing)
            {
                model.EntryIngredients.Add(new EntryIngredient { Ingredient = item, IngredientQuantity = 0 });
            }

            foreach (var item in rec)
            {
                item.IsNew = false;
                model.EntryRecipes.Add(new EntryRecipe { Recipe = item });
            }

            return View(model);
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntriesCreateModel entry, int uid)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(UserProfileController.SignIn));
            }

            if (true/*ModelState.IsValid*/)
            {
                entry.UserProfileId = (int)HttpContext.Session.GetInt32("Id");

                ICollection<EntryIngredient> ing = new List<EntryIngredient>();
                ICollection<EntryRecipe> rec = new List<EntryRecipe>();

                var en = new Entry
                {
                    Date = entry.Date,
                    UserProfileId = entry.UserProfileId,

                };

                _context.Add(en);
                _context.SaveChanges();


                foreach (var item in entry.EntryRecipes.Where(i => i.Recipe.IsNew == true))
                {
                    rec.Add(new EntryRecipe
                    {
                        RecipeId = item.Recipe.Id,
                        Entry = en,
                        EntryId = en.Id
                    });
                }

                _context.EntryRecipes.AddRange(rec);
                _context.SaveChanges();

                foreach (var item in entry.EntryIngredients.Where(i=>i.IngredientQuantity > 0))
                {
                    ing.Add(new EntryIngredient
                    {
                        IngredientId = item.Ingredient.Id,
                        IngredientQuantity = item.IngredientQuantity,
                        Entry = en,
                        EntryId = en.Id
                    });
                }

                _context.EntryIngredients.AddRange(ing);
                _context.SaveChanges();


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

            var entry = await _context.Entries.AsNoTracking()
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
