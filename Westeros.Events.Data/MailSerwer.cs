using System;
using System.Collections.Generic;
using System.Linq;
namespace Westeros.Events.Data
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


        private List<Message> EmailServer = new List<Message>();
        private Boolean RunningFlag = false;

        public void SendMessage(Message message)
        {
            EmailServer.Add(message);
            if (!RunningFlag)
                CheckMessage();
        }

        private void CheckMessage()
        {
            while (EmailServer.Count > 0)
            {
                if (!RunningFlag)
                    RunningFlag = true;
                Message ActMessage = EmailServer.ElementAt(0);
                EmailServer.RemoveAt(0);
                if (UserProfiles.Instance.ProfileList.Exists(
                    e => e.NickName.Equals(ActMessage.To, StringComparison.OrdinalIgnoreCase)))
                    RedirectMessage(ActMessage);
                else
                    NoReciver(ActMessage);
            }
            RunningFlag = false;
            // check if there is a reciver if yes send to him and LOG
        }

        private void RedirectMessage(Message message)
        {
            Console.WriteLine("asd");

            MailDb.Instance.AddMessage(message);
            //SEND to reciver and LOG
        }
        private void NoReciver(Message message)
        {
            MailDb.Instance.AddErrorMessage(message);

            //SEND an info that no reciver
        }




    }

}