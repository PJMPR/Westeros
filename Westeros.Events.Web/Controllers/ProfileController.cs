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
    public class ProfileController : Controller
    {
        EventContext _ctx;

        public ProfileController(EventContext ctx)
        {
            _ctx = ctx;
        }

        // -------------------------------------------GET: User-----------------------------------------------------
        public ActionResult Index()
        {
            return View();
        }

        // -------------------------------------------GET: User/Details/5
        public ActionResult Details(int id,[FromRoute] int? profileId)
        {
            if (profileId != null)
                id = profileId.Value;
            var user = _ctx.Profiles.FirstOrDefault(x => x.Id == id);

            return View(user);
        }

        // -------------------------------------------GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // -------------------------------------------POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profile profile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ctx.Profiles.Add(profile);
                    _ctx.SaveChanges();
                }
                else
                    return View(profile);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // -------------------------------------------GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // -------------------------------------------POST: User/Edit/5
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

        // -------------------------------------------GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // -------------------------------------------POST: User/Delete/5
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