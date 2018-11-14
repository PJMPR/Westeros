using System;

namespace Westeros.Events.Data.Model
{
    public class Message
    {
        public int Id { get;private set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
        public String Date { get; set; }


        public Message RetTo(Message oldMessage,string newTo)
        {   oldMessage.To = newTo;
            return oldMessage;
        }
        public Message RetFrom(Message oldMessage, string newFrom)
        {
            oldMessage.From = newFrom;
            return oldMessage;
        }
        public Message RetContent(Message oldMessage, string newContent)
        {
            oldMessage.Content = newContent;
            return oldMessage;
        }


        public Message()
        {}
       
     
    }
}

