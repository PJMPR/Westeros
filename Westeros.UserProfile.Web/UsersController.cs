﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Westeros.UserProfile.Data;
using Westeros.UserProfile.Data.Repositories;
using Westeros.UserProfile.Data.Services;
using Microsoft.AspNetCore.Http;

namespace Westeros.UserProfile.Web
{
    public class UsersController : Controller
    {
        private readonly UserDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        

        public UsersController(UserDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession _session => _httpContextAccessor.HttpContext.Session;

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }
        // GET: Users/Register/5
        public ActionResult Register()
        {
            return View();
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (_context.User.Find(id).login == _session.GetString("login"))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.User
                    .SingleOrDefaultAsync(m => m.id == id);
                if (user == null)
                {
                    return NotFound();
                }

                if (user.height != null && user.weight != null)
                {
                    Calculator c = new Calculator();
                    ViewBag.BMR_H = c.BMR_Harrisa_Benedicta(user);
                    ViewBag.BMR_M = c.BMR_Mifflin_StJeor(user);
                    ViewBag.BMI = c.BMI(user);
                }
                return View(user);
            }
            else
            {
                return RedirectToAction(nameof(Temporary));
            }
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Temporary/5
        [HttpGet("Users/Temporary/5")]
        public IActionResult Temporary()
        {
            return View();
        }

        // GET: Users/Edit/5
        [HttpGet("Users/Edit/5")]
        public IActionResult Edit(User U)
        {
            User user = _context.User.Find(U.id);
            U.login = user.login;
            U.email = user.email;
            if (ModelState.IsValid && _session.GetString("login") == user.login)
                using (UserDbContext dc = new UserDbContext())
                {

                    dc.User.Update(U);

                    dc.SaveChanges();

                    ModelState.Clear();

                    U = null;

                }
            else
            {
                return RedirectToAction("Temporary");
            }

            return View(U);
        }

        [HttpPost("Users/Edit/5")]
        public IActionResult Edit()
        {
            ViewData["Message"] = "Successful edit!";
            return View();
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User U)

        {

            if (ModelState.IsValid)
                using (UserDbContext dc = new UserDbContext())
                {

                dc.User.Add(U);

                dc.SaveChanges();

                ModelState.Clear();

                ViewData["Message"] = "Successfull Registration";

            }

            return View();

        }
        public async Task<IActionResult> Edit(int id, [Bind("id")] User user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .SingleOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.SingleOrDefaultAsync(m => m.id == id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.id == id);
        }

        // GET: Users/Login/5
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Login/5
        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string login)
        {
            var users = _context.User.ToList();
            foreach(var user in users)
            {
                if(user.login == login)
                {
                    _session.SetString("login", user.login);
                    return RedirectToAction(nameof(Details), user);
                }
            }
            ViewData["Message"] = "Incorrect login";
            return View();
        }

        // GET: Calculators/WHR/5
        [HttpGet("Users/WHR/5")]
        public IActionResult WHR(int? id)
        {
            if(_session.GetString("login") == _context.User.Find(id).login)
            {
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Temporary));
            }
        }

        // POST: Calculators/WHR/5
        [HttpPost, ActionName("WHR")]
        [ValidateAntiForgeryToken]
        public IActionResult WHR(int? id, decimal waist, decimal hip)
        {
            if(_session.GetString("login") == _context.User.Find(id).login)
            {
                ViewBag.waist = 0;
                ViewBag.hip = 0;

                Calculator c = new Calculator();
                decimal x = Convert.ToDecimal(TempData["waist"]);
                decimal y = Convert.ToDecimal(TempData["hip"]);
                decimal result = c.WHR(hip, waist);
                ViewData["Result"] = "Your result is: " + result + ".";
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Temporary));
            }
        }
    }
}
