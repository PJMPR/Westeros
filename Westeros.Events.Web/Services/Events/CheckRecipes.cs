using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Westeros.Events.Data;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Web.Services.Events
{
    public class CheckRecipes
    {
        private IGenericRepository<Recipe> _Rctx;
        private IGenericRepository<Profile> _Pctx;
        IEventSender _EventSender;
        public CheckRecipes(IGenericRepository<Recipe> Rrepo, IGenericRepository<Profile> Prepo, IEventSender EventSender)
        {
            _Rctx = Rrepo;
            _Pctx = Prepo;
            _EventSender = EventSender;
        }

        public void CheckNew()
        {
           
            var data = _Rctx.Get(x => x.IsNew == true);
                if (data.Count<Recipe>() > 10)
                {
                    foreach (Recipe r in data)
                    {
                        var profiles = GetTypedProfiles(r.Tag);
                        if (profiles != null)
                        {
                        var one =profiles.ElementAt(0);
                            SendEvent(r, profiles);
                        }
                        r.IsNew = false;
                    _Rctx.Update(r);
                    _Rctx.SaveChanges();

                    }

                }
            

        }
        private IEnumerable<Profile> GetTypedProfiles(String tag)
        {
            
                var profiles = _Pctx.Get(x => x.Tag.Equals(tag));

                return profiles;
            
        }
        private void SendEvent(Recipe recipe, IEnumerable<Profile> profiles)
        {
            foreach(Profile p in profiles)
            {
                _EventSender.SendEventMessage(p, recipe);
            }

            
        }
    }
}
