using Westeros.Events.Data.Model;

namespace Westeros.Events.Web.Services.Events
{
    public interface IEventSender
    {
        void SendEventMessage(Profile profile, Recipe recipe);
    }
}