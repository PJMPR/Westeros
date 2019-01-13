using Westeros.Events.Data.Model;

namespace Westeros.Events.Web.Services.Messages
{
    public interface IMyMapper
    {
        MailServer MapMail(IMessage msg);
    }
}