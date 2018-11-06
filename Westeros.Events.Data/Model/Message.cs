using System;

namespace Westeros.Events.Data.Model
{
    public class Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
     
        public String Date { get; set; }

 


        public Message(string to,string from, string topic,string content)
        {
            To = to;
            From = from;
            Topic = topic;
            Content = content;
            Date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
       
     
    }
}

