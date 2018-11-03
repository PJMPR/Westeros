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

        public void AddMessage(Message message)
        {
            LOG.Add(message);
        }
        public void AddErrorMessage(Message message)
        {
            message.Topic = "Error" + message.Topic;
            LOG.Add(message);
        }

    }
}
