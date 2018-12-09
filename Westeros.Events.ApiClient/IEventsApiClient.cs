using System.Collections.Generic;
using Westeros.Events.Data.Model;

namespace Westeros.Events.ApiClient
{
    public interface IEventsApiClient
    {
        void SendMessage(Message message);
        IEnumerable<Message> All();
        void DeleteMessage(int id);
        Message GetById(int id);

    }
}