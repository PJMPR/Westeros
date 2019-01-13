using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Westeros.Recipes.Data.Model;
using Westeros.Recipes.Data.Repositories;
using Westeros.Recipes.Web.Models;

namespace Westeros.Recipes.Web.Controllers
{
    public class RecipeController : Controller
    {
        RecipesDbContext _context;
        // Old way of doing things
        //IGenericRepository<Recipe> _repository;

        //public RecipeController(IGenericRepository<Recipe> ctx)
        //{
        //    _repository = ctx;
        //}

        public RecipeController(RecipesDbContext ctx)
        {
            _context = ctx;
        }

        public IActionResult Index()
        {
            //var recipeList = _repository.Get();
            var recipeList = _context.Recipes.Include(r => r.RecipeIngredients).ThenInclude( r => r.Ingredient);
            return View(recipeList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new RecipesModel();
            var Ingredients = _context.Ingredients.ToList();

            foreach (var ing in Ingredients)
            {
                model.RecipeIngredients.Add(new RecipeIngredient
                {
                    Ingredient = ing, IngredientId = ing.Id,
                    IngredientQuantity = 0
                });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipesModel recipe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(recipe);
                    _context.SaveChanges();
                }
                else return View(recipe);

                return Redirect(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}