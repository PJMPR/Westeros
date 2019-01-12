using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Westeros.Recipes.Data.Model;
using Westeros.Recipes.Data.Repositories;

namespace Westeros.Recipes.Web.Controllers
{
    public class RecipeController : Controller
    {
        IGenericRepository<Recipe> _repository;

        public RecipeController(IGenericRepository<Recipe> ctx)
        {
            _repository = ctx;
        }
        public IActionResult Index()
        {
            var recipeList = _repository.Get();
            return View(recipeList);
        }
    }
}