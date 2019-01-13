
using Westeros.Events.Data.Model;

namespace Westeros.Events.Web.Services.Messages
{
    class MyMapper : IMyMapper
    {
        public MailServer MapMail(IMessage msg)
        {
            MailServer NewMsg =new MailServer();
            NewMsg.IsNew = false;
            NewMsg.To = msg.To;
            NewMsg.From = msg.From;
            NewMsg.Content = msg.Content;
            NewMsg.Topic = msg.Topic;
            return NewMsg;
        }

    }
}
