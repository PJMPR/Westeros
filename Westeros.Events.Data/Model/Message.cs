using System;

namespace Westeros.Events.Data.Model
{
    public class Message
    {
        public int Id { get;private set; }
        public string To { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
        public String Date { get; set; }
        public Profile Receiver { get; set; }
        public Profile Sender { get; set; }




        public Message()
        {}
       
     
    }
}

