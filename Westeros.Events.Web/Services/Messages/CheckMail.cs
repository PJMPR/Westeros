
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Web.Services.Messages
{
    public class CheckMail
    {
        private IGenericRepository<MailServer> _MSrepo;
        private IGenericRepository<IMessage> _IMrepo;
        private IGenericRepository<LogRecord> _Lgrepo;
        private IGenericRepository<Profile> _Prepo;
        AutoMapper.IMapper _mapper;

        public CheckMail(IGenericRepository<MailServer> MSrepo,
            IGenericRepository<IMessage> IMrepo,
            IGenericRepository<LogRecord> Lgrepo,
             IGenericRepository<Profile> Prepo,
             AutoMapper.IMapper mapper)
        {
            _MSrepo = MSrepo;
            _IMrepo = IMrepo;
            _Lgrepo = Lgrepo;
            _Prepo = Prepo;
            _mapper = mapper;

        }

        public void CheckNew()
        {

            var data = _MSrepo.Get(x => x.IsNew == true);
           
                foreach (MailServer m in data)
                {
                Message msg = new Message();
                msg.To = m.To;
                msg.From = m.From;
                msg.Content = m.Content;
                msg.Topic = m.Topic;
                if (CheckReceiver(msg.To) != null)
                    {
                        RedirectMessage(msg);
                    }
                    else
                    {

                        NoReciver(msg);
                    }
                m.IsNew = false;
                _MSrepo.Update(m);
                _MSrepo.SaveChanges();

                }
        }
        private void RedirectMessage(Message message)
        {
            Console.WriteLine("asd");

           _IMrepo.Insert(message);
            _Lgrepo.Insert(new LogRecord
            {
                Message = message,
                Status = "Succeed"
            });
            _IMrepo.SaveChanges();
            _Lgrepo.SaveChanges();

            //SEND to reciver and LOG
        }
        private void NoReciver(Message message)
        {

            Message returnedMessage = new Message();
            returnedMessage.To = message.From;
            returnedMessage.From = "Service@Westeros";
            returnedMessage.Content = "The reciver was not found";

            _IMrepo.Insert(returnedMessage);
            _IMrepo.Insert(message);      //FOR INBOX OUTBOX
            _Lgrepo.Insert(new LogRecord
            {
                Message = message,
                Status = "Failed"
            });

            _IMrepo.SaveChanges();
            _Lgrepo.SaveChanges();

            //SEND an info that no reciver
        }

        private Profile CheckReceiver(String s)
        {

            var ReceiverProfile = _Prepo.Get
               (b => b.NickName.Equals(s));

            if (ReceiverProfile.ElementAtOrDefault(0)!=null)
                return ReceiverProfile.ElementAt(0);
            else
                return null;


        }
    }
}
