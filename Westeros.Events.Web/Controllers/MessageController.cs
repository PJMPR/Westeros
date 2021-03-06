﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Westeros.Events.Data.Model;
using Westeros.Events.Data;
using Westeros.Events.Data.Repositories;
using Westeros.Events.Web.Services.Messages;

namespace Westeros.Events.Web.Controllers
{
    public class MessageController : Controller
    {
        EventContext _ctx;
        IMessageSender _MailSender;  

        public MessageController(EventContext ctx, IMessageSender MessageSender)
        {
            _ctx = ctx;
            _MailSender = MessageSender;
        }
        // GET: Message
        public ActionResult Index()
        {

            var data = _ctx.MailDB.OrderBy(x => x.Date);
            return View(data);
        }
     

        // GET: Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var message = _ctx.MailDB.FirstOrDefault(x => x.Id == id);
            if (message.ReadFlag != true)
            {
                message.ReadFlag = true;
                _ctx.Update(message);
                _ctx.SaveChanges();
            }

            return View(message);
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _MailSender.SendMessage(message);
                }
                else
                    return View(message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return View();
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

           
            IMessage message = _ctx.MailDB.Find(id);
            if (message == null)
            {
               return NotFound();
            }
            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            IMessage message = _ctx.MailDB.Find(id);
            
            _ctx.MailDB.Remove(message);
            _ctx.SaveChanges(); 
            
            return RedirectToAction("Index");

        }
    }
}