using System;
using System.ComponentModel.DataAnnotations;


namespace Westeros.Events.Data.Model
{
    public class Message : IMessage
    {
       
    
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

