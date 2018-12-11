using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Web.Controllers
{
    public class RecipeController : Controller
    {
        EventContext _ctx;

        public RecipeController(EventContext ctx)
        {
            _ctx = ctx;
        }
        // GET: Recipe
        public ActionResult Index()
        {
            var data = _ctx.RecipeDb.OrderBy(x => x.Tag);
            return View(data);
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id, [FromRoute] int? recipeId)
        {
            if (recipeId != null)
                id = recipeId.Value;

            var recipe = _ctx.RecipeDb.FirstOrDefault(x => x.Id == id);
            
     
            return View(recipe);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recipe recipe)
        {
            try
            {
                // TODO: Add insert logic here
                _ctx.RecipeDb.Add(recipe);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipe/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}