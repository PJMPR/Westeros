using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Westeros.Diet.Data.Repositories;

namespace Westeros.Diet.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly DietDbContext _context;

        public RecipeController(DietDbContext context )
        {
            _context = context;
        }
        
        // GET: Recipe
        public async Task<IActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
               return RedirectToAction(nameof(UserProfileController.SignIn));
            }
            else
            {
                return View(await _context.Recipes.ToListAsync());
            }
        
        }

        // GET: Recipe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(UserProfileController.SignIn));
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }
                var recipe = await _context.Recipes
                    .SingleOrDefaultAsync(m => m.Id == id);
                if (recipe == null)
                {
                    return NotFound();
                }
                return View(recipe);
            }
       
        }

        // GET: Recipe/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(UserProfileController.SignIn));
            }
            else
            {
                return View();
            }
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cuisine,Desription,PrepTime,Difficulty")] Data.Recipe recipe )
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(UserProfileController.SignIn));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(recipe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexAsync));
                }
                return View(recipe);
            }
        }

        // GET: Recipe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(UserProfileController.SignIn));
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }
                var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.Id == id);
                if (recipe == null)
                {
                    return NotFound();
                }
                return View(recipe);
            }
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cuisine,Desription,PrepTime,Difficulty")] Data.Recipe recipe)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
               return RedirectToAction(nameof(UserProfileController.SignIn));
            }
            else
            {
                if (id != recipe.Id)
                {
                    return NotFound();

                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(recipe);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RecipeExists(recipe.Id))
                        {
                            return NotFound();
                        }
                        throw;
                    }
                    return RedirectToAction(nameof(IndexAsync));
                }
                return View(recipe);
            }
        }

       
        // GET: Recipe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
               return RedirectToAction(nameof(UserProfileController.SignIn));
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }
                var recipe = await _context.Recipes
                    .SingleOrDefaultAsync(m => m.Id == id);
                if (recipe == null)
                {
                    return NotFound();
                }
                return View(recipe);
            }
        }

        // POST: Recipe/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexAsync));
        }
        public void CheckSession()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                 RedirectToAction(nameof(UserProfileController.SignIn));
            }
        }
        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}