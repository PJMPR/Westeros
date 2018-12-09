using System;
using System.Collections.Generic;
using System.Linq;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Data
{
    public class EventSender
    {
        private static EventSender instance = null;
        private static readonly object padlock = new object();




        EventSender()
        {
        }

        public static EventSender Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new EventSender();
                    }
                    return instance;
                }
            }
        }

        public void SendEventMessage(Profile profile,Recipe recipe)
        {
            using (var context = new EventContext())
            {
                EventMessage msg = new EventMessage();
                msg.To = profile.NickName;
                msg.From = "Admin@recipes.com";
                msg.Topic = "New Recipes from"+recipe.Tag;
                
                msg.Content = "<a href=\"http://localhost:51764/Recipe/Details/"+recipe.Id+"\">Recipe link</a>";

                context.MailDB.Add(msg);
                context.LogDb.Add(new LogRecord
                {
                    Message = msg,
                    Status = "Succeed"
                });
                context.SaveChanges();

            }
        }
     


       




        




    }

}