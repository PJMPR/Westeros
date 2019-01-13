using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Westeros.Recipes.Data.Model;
using Westeros.Recipes.Data.Repositories;

namespace Westeros.Recipes.Web.Controllers
{
    public class IngredientController : Controller
    {
        RecipesDbContext _context;

        public IActionResult Index()
        {
            return View();
        }


        public IngredientController(RecipesDbContext ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new Ingredient();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ingredient ingredient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(ingredient);
                    _context.SaveChanges();
                }
                else return View(ingredient);

                return Redirect(nameof(Create));
            }
            catch
            {
                return View();
            }
        }
    
}
}