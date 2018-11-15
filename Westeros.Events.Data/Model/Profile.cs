using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;

namespace Westeros.Events.Data.Model
{
   

    public class Profile
    {
        public int Id { get;private set; }

        [Required]
        public String NickName { get; set; }
        public String Name { get; set; }
      
        public Profile()
        {
        }
    }
}