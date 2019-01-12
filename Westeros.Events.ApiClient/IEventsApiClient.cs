using System.Collections.Generic;
using Westeros.Events.ApiClient.Contracts;

namespace Westeros.Events.ApiClient
{
    public interface IEventsApiClient
    {
        void SendMessage(MessageDto message);
        IEnumerable<MessageDto> All();
        void DeleteMessage(int id);
        MessageDto GetById(int id);

    }
}