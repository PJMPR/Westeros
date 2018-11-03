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
                if (UserProfiles.ProfileList.get.Exists(
                    e => e.NickName.get == EmailServer.ElementAt(0)))
                    RedirectMessage();
                


            }
            RunningFlag = false;
           // check if there is a reciver if yes send to him and LOG
        }



        private void RedirectMessage()
        {
            //SEND to reciver and LOG
        }
        private void NoReciver(Message message)
        {
            //SEND an info that no reciver
        }




    }

}
