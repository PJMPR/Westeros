using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Westeros.Recipes.Data.Model;
using Westeros.Recipes.Data.Repositories;

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
    }
}