using System;

namespace Westeros.Events.Data
{
    public class Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }



        public Message(string to,string from,string content)
        {
            To = to;
            From = from;
            Content = content;
            Date = Date.Date.ToUniversalTime();
        }
     
    }
}

