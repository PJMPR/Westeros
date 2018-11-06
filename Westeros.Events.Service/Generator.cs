using System;
using System.Collections.Generic;
using System.Text;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Service
{
    class Generator
    {
        public void ProfileGenerator()
        {
            using (var context = new EventContext())
            {
                 
                context.Profiles.Add(new Profile {
                    NickName="Demo1",
                    Name="Demon"
                });
                context.Profiles.Add(new Profile
                {
                    NickName = "Demo2",
                    Name = "Demon"
                });
                context.Profiles.Add(new Profile
                {
                    NickName = "Demo3",
                    Name = "Demon"
                });
                context.Profiles.Add(new Profile
                {
                    NickName = "Demo4",
                    Name = "Demon"
                });
                context.Profiles.Add(new Profile
                {
                    NickName = "Demo5",
                    Name = "Demon"
                });
                context.Profiles.Add(new Profile
                {
                    NickName = "Demo6",
                    Name = "Demon"
                });
                context.Profiles.Add(new Profile
                {
                    NickName = "Demo7",
                    Name = "Demon"
                });
                
                context.SaveChanges();
            }

        }

    }
}
