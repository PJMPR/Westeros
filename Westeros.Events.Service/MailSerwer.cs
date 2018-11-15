using System;
using System.Collections.Generic;
using System.Linq;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Service
{
    public class MailSerwer
    {
        private static MailSerwer instance = null;
        private static readonly object padlock = new object();


 

        MailSerwer()
        {
        }

        public static MailSerwer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MailSerwer();
                    }
                    return instance;
                }
            }
        }


        private List<Message> EmailServerList = new List<Message>();
        private Boolean RunningFlag = false;

        public void SendMessage(Message message)
        {
            EmailServerList.Add(message);
            if (!RunningFlag)
                CheckMessage();
        }

        private void CheckMessage()
        {
            while (EmailServerList.Count > 0)
            {
                if (!RunningFlag)
                    RunningFlag = true;
                Message ActMessage = EmailServerList.ElementAt(0);
                EmailServerList.RemoveAt(0);
                if (CheckReceiver(ActMessage.To)!=null){
                    RedirectMessage(ActMessage);
                }
                else{

                    NoReciver(ActMessage);
                }
                    
            }
            RunningFlag = false;
            // check if there is a reciver if yes send to him and LOG
        }

        private void RedirectMessage(Message message)
        {
            Console.WriteLine("asd");
            using (var context = new EventContext())
            {
                context.MailDB.Add(message);
                context.LogDb.Add(new LogRecord
                {
                    Message = message,
                    Status = "Succeed"
                });

                context.SaveChanges();
            }
            //MailDb.AddMessage(message);
            //SEND to reciver and LOG
        }
        private void NoReciver(Message message)
        {
            using (var context = new EventContext())
            {
                Message returnedMessage= new Message();
                returnedMessage.To = message.From;
                returnedMessage.From = "Service@Westeros";
                returnedMessage.Content =  "The reciver was not found";

                context.MailDB.Add(returnedMessage);
               context.MailDB.Add(message);      //FOR INBOX OUTBOX
                context.LogDb.Add(new LogRecord
                {
                    Message = message,
                    Status = "Failed"
                });

                context.SaveChanges();
            }
            //  MailDb.Instance.AddErrorMessage(message);

            //SEND an info that no reciver
        }

        private Profile CheckReceiver(String s)
        {
            using (var context = new EventContext())
            {
                var ReceiverProfile = context.Profiles
                    .FirstOrDefault(b => b.NickName.Equals(s));

                if (ReceiverProfile != null)
                    return ReceiverProfile;
                else
                    return null;
               
            }
           

            

        }




    }

}