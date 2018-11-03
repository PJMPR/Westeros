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
        public List<Profile> ProfileList { get; set; } = new List<Profile>();

        public void AddProfile(String NickName, String Name)
        {
            ProfileList.Add(new Profile(NickName, Name));
        }
        public void GenerateProfiles(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string NickName = "Demo" + i + 1;
                AddProfile(NickName, NickName);
            }
            AddProfile("DEmo1", "Albert");

        }
    }


    public class Profile
    {
        public static int ProfileId;

        public String NickName { get; set; }
        private String Name { get; set; }
        private int Id { get; set; }
        public Profile(String NickName, String Name)
        {
            this.NickName = NickName;
            this.Name = Name;
            this.Id = Interlocked.Increment(ref ProfileId);
        }
    }
}