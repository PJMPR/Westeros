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
        IGenericRepository<UserProfile> _repository;
        private readonly UserManager<UserProfileModel> _userManager;
        private readonly SignInManager<UserProfileModel> _signInManager;

        public UserProfileController(IGenericRepository<UserProfile> ctx,
                                    UserManager<UserProfileModel> userManager,
                                    SignInManager<UserProfileModel> signInManager)
        {
            _repository = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string returnUrl = null)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                RedirectToAction(nameof(SingIn));
            }

            return View();
        }

        // GET: UserProfiles
        public ActionResult SingIn()
        {
            ViewBag.Message = "User sing in, choose your profile.";

            var data = _repository.Get();
            List<UserProfileModel> userProfiles = new List<UserProfileModel>();

            foreach (var row in data)
            {
                userProfiles.Add(new UserProfileModel
                {
                    Id = row.Id,
                    Name = row.Name,
                    LastName = row.Surname,
                    Login = row.Login,
                    Email = row.Email,
                    Sex = row.Sex,
                    Age = row.Age,
                    Weight = row.Age,
                    Height = row.Height
                });
            }

            return View(userProfiles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SingIn(UserProfileModel profileModel)
        {
            if (_repository.GetByID(profileModel.Id) == null)
            {
                return View();
            }

            HttpContext.Session.SetInt32("Id", profileModel.Id);
            HttpContext.Session.SetString("Name", profileModel.Name);

            return RedirectToAction(nameof(Index));

        }

        public ActionResult SingOut()
        {

            HttpContext.Session.remove
            HttpContext.Session.SetString("Name", profileModel.Name);

            return RedirectToAction(nameof(Index));

        }

        //// GET: UserProfiles/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: UserProfiles/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UserProfiles/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserProfiles/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UserProfiles/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserProfiles/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserProfiles/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}