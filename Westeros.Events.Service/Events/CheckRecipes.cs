using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Data.Events
{
    public class CheckRecipes
    {
        private IGenericRepository<Recipe> _Rctx;
        private IGenericRepository<Profile> _Pctx;
        public CheckRecipes(IGenericRepository<Recipe> Rrepo, IGenericRepository<Profile> Prepo)
        {
            _Rctx = Rrepo;
            _Pctx = Prepo;
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
                EventSender.Instance.SendEventMessage(p, recipe);
            }

            
        }
    }
}
