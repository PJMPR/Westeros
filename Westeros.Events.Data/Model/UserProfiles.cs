using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Westeros.Events.Data.Model
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

        public void AddProfile(Profile profile)
        {
            ProfileList.Add(profile);
        }
        public void GenerateProfiles(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string NName = "Demo" + i + 1;
                AddProfile(new Profile {
                    NickName = NName,
                     Name = NName
                });
            }
            AddProfile(new Profile
            {
                NickName = "DEmo1",
                Name = "Albert"
            });
    
        }
            

        }
    


    public class Profile
    {
        public static int ProfileId;

        public String NickName { get; set; }
        public String Name { get; set; }
        private int Id { get; set; }
        public Profile()
        {
            this.Id = Interlocked.Increment(ref ProfileId);
        }
    }
}