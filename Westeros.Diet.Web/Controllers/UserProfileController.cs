using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Westeros.Diet.Data.Repositories;
using Westeros.Diet.Data.Model;
using Westeros.Diet.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Westeros.Diet.Web.Controllers
{
    public class UserProfileController : Controller
    {

        private readonly DietDbContext _context;

        public UserProfileController(DietDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string returnUrl = null)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(SingIn));
            }
            ViewBag.Name = HttpContext.Session.GetString("Name");

            int t = HttpContext.Session.GetInt32("Id").GetValueOrDefault();

            var entry = await _context.UserProfiles.SingleOrDefaultAsync(u => u.Id == t);
            if (entry == null)
            {
                return NotFound();
            }
            return View(contextToModel(entry));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, [Bind("Id, Name, LastName, Login, Email, ConfirmEmail, Sex, Age, Weight, Height")] UserProfileModel userProfile)
        {
            if (id != userProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var up = modelToContext(userProfile);

                _context.Update(up);
                await _context.SaveChangesAsync();


                return RedirectToAction("Index");
            }
            return View(userProfile);
        }

        // GET: UserProfiles
        public ActionResult SingIn(int? id)
        {
            ViewBag.Message = "User sing in, choose your profile.";

            if (id != null)
            {
                int t = id ?? default(int);
                var name = _context.UserProfiles.Single(u => u.Id == t).Name;
                HttpContext.Session.SetInt32("Id", t);
                HttpContext.Session.SetString("Name", name);

                return RedirectToAction(nameof(Index));
            }

            var data = _context.UserProfiles.ToList();
            List<UserProfileModel> userProfiles = new List<UserProfileModel>();

            foreach (var row in data)
            {
                userProfiles.Add(contextToModel(row));
            }

            return View(userProfiles);
        }

        private static UserProfileModel contextToModel(UserProfile row)
        {
            return new UserProfileModel
            {
                Id = row.Id,
                Name = row.Name,
                LastName = row.Surname,
                Login = row.Login,
                Email = row.Email,
                ConfirmEmail = row.Email,
                Sex = row.Sex,
                Age = row.Age,
                Weight = row.Age,
                Height = row.Height
            };
        }


        private static UserProfile modelToContext(UserProfileModel row)
        {
            return new UserProfile
            {
                Id = row.Id,
                Name = row.Name,
                Surname = row.LastName,
                Login = row.Login,
                Email = row.Email,
                Sex = row.Sex,
                Age = row.Age,
                Weight = row.Age,
                Height = row.Height
            };
        }

        public ActionResult SingOut()
        {
            HttpContext.Session.Clear();
            //HttpContext.Session.SetString("Name", profileModel.Name);

            return RedirectToAction(nameof(UserProfileController.Index), "UserProfile");

        }
    }
}