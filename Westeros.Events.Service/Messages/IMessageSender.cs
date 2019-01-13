using Westeros.Events.Data.Model;

namespace Westeros.Events.Web.Services.Messages
{
    public interface IMessageSender
    {
        void SendMessage(Message message);
    }
}