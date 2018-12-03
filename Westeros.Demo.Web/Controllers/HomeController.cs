using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Westeros.Demo.Data.Services;
using Westeros.Demo.Web.Models;

namespace Westeros.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculator _calculator;
        public HomeController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public IActionResult Index()
        {
            _calculator.execute();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

           
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
