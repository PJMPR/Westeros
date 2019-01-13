using Westeros.Events.Data.Model;

namespace Westeros.Events.Web.Services.Messages
{
    public interface IMailSerwer
    {
        void SendMessage(Message message);
    }
}