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

        public UserProfileController(IGenericRepository<UserProfile> ctx)
        {
            _repository = ctx;
        }

        public ActionResult Index(string returnUrl = null)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction(nameof(SingIn));
            }
            ViewBag.Message = "Nie";

            return View();
        }

        // GET: UserProfiles
        public ActionResult SingIn(int? id)
        {
            ViewBag.Message = "User sing in, choose your profile.";

            if (id != null)
            {
                int t = id ?? default(int);
                HttpContext.Session.SetInt32("Id", t);
                //HttpContext.Session.SetString("Name", Name);

                return RedirectToAction(nameof(Index));
            }

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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SingIn(UserProfileModel profileModel)
        //{
        //    if (_repository.GetByID(profileModel.Id) == null)
        //    {
        //        return View();
        //    }

        //    HttpContext.Session.SetInt32("Id", profileModel.Id);
        //    HttpContext.Session.SetString("Name", profileModel.Name);

        //    return RedirectToAction(nameof(Index));

        //}

        public ActionResult SingOut()
        {

            HttpContext.Session.Clear();
            //HttpContext.Session.SetString("Name", profileModel.Name);

            return RedirectToAction(nameof(Index));

        }
    }
}