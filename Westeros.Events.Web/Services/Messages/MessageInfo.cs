
using System.Linq;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Web.Services.Messages
{
    public class MessagesInfo
    {
        EventContext _ctx;

        public MessagesInfo(EventContext ctx)
        {
            _ctx = ctx;
        }

        public int MessageCount()
        {
            return _ctx.MailDB.Count(x => x.ReadFlag == false);

            // var response =_ctx.Find(Messages, id);
        }
    }
}
