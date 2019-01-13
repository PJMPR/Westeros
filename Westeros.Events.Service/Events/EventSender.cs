
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;
using Westeros.Events.Web.Services.Messages;

namespace Westeros.Events.Web.Services.Events
{
    public class EventSender : IEventSender
    {
        private IGenericRepository<IMessage> _IMrepo;
        private IGenericRepository<LogRecord> _Lgrepo;
        private ILinkGenerator _linkGenerator;
        private IMyMapper _mapper;
        
        public EventSender(
            IGenericRepository<IMessage> IMrepo,
            IGenericRepository<LogRecord> Lgrepo,
            ILinkGenerator linkGenerator,
            IMyMapper mapper)
        {
            _IMrepo = IMrepo;
            _Lgrepo = Lgrepo;
            _linkGenerator =linkGenerator;
            _mapper = mapper;
        }


        public void SendEventMessage(Profile profile,Recipe recipe)
        {
           
                EventMessage msg = new EventMessage();
                msg.To = profile.NickName;
                msg.From = "Admin@recipes.com";
                msg.Topic = "New Recipes from"+recipe.Tag;
                
               msg.Content = _linkGenerator.GenerateRecipeLink(recipe.Id);

                _IMrepo.Insert(msg);
                _Lgrepo.Insert(new LogRecord
                {
                    Message = _mapper.MapMail(msg),
                    Status = "Succeed"
                });
                _IMrepo.SaveChanges();
                _Lgrepo.SaveChanges();
        }

    }

}