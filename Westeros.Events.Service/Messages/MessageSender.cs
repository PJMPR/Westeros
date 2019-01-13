
using System;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Web.Services.Messages
{
    public class MessageSender : IMessageSender
    {
        IGenericRepository<MailServer> _Mctx;

        public MessageSender(IGenericRepository<MailServer> Mctx)
        {
            _Mctx = Mctx;

        }
        public void SendMessage(Message message)
        {
            message.Date = DateTime.Now;
            MailServer msg = new MailServer();
            msg.To = message.To;
            msg.From = message.From;
            msg.Content = message.Content;
            msg.Topic = message.Topic;
            

            _Mctx.Insert(msg);
            _Mctx.SaveChanges();
        }

    }
}
