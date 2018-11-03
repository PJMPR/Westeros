using System;
using System.Collections.Generic;

namespace Westeros.Events.Data
{

    public class MailDb
	{
        private static MailDb instance = null;
        private static readonly object padlock = new object();

        MailDb()
        {
        }

        public static MailDb Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MailDb();
                    }
                    return instance;
                }
            }
        }

        public List<Message> LOG { get; set; } = new List<Message>();

        public Boolean AddMessage(Message message)
        {

            return false;
        }
        public Boolean AddErrorMessage(Message message)
        {


            return false;
        }

    }
}
