using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Westeros.Events.Data
{
    public class UserProfiles
    {
        private static UserProfiles instance = null;
        private static readonly object padlock = new object();

        UserProfiles()
        {
        }

        public static UserProfiles Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserProfiles();
                    }
                    return instance;
                }
            }
        }



        public List<Profile> ProfileList {public get; set; } = new List<Profile>();

        public void AddProfile(String NickName,String Name)
        {
            ProfileList.Add(new Profile(NickName, Name));
        }
        

    }




    public class Profile
    {
        public static int ProfileId;

        private String NickName { get; set; }
        private String Name { get; set; }
        private int Id { get; set; }
        public Profile(String NickName, String Name)
        {
            this.NickName = NickName;
            this.Name = Name;
            this.Id= Interlocked.Increment(ref ProfileId);
        }
    }
}
