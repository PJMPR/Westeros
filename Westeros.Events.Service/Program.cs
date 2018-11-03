using System;
using Westeros.Events.Data;

namespace Westeros.Events.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("marmolada");

            UserProfiles.Instance.GenerateProfiles(10);
            MailSerwer.Instance.SendMessage(new Message("Demo1", "Demo1", "DemoTopic",
                "as;ldmaodjaml\n" +
                "asdadassdad"));


            MailSerwer.Instance.SendMessage(new Message("Demo3", "Demo1", "DemoTopic",
                "as;ldmaodjaml\n" +
                "asdadassdad"));


            MailSerwer.Instance.SendMessage(new Message("Demo5", "Demo1", "DemoTopic",
                "as;ldmaodjaml\n" +
                "asdadassdad"));


            MailSerwer.Instance.SendMessage(new Message("Demo1", "Demo1", "DemoTopic",
                "as;ldmaodjaml\n" +
                "asdadassdad"));


            MailSerwer.Instance.SendMessage(new Message("Demo2", "Demo1", "DemoTopic",
                "as;ldmaodjaml\n" +
                "asdadassdad"));


            MailSerwer.Instance.SendMessage(new Message("Demo6", "Demo1", "DemoTopic",
                "as;ldmaodjaml\n" +
                "asdadassdad"));


            MailSerwer.Instance.SendMessage(new Message("Demo10", "Demo1", "DemoTopic",
                "as;ldmaodjaml\n" +
                "asdadassdad"));


            MailSerwer.Instance.SendMessage(new Message("Demo15", "Demo1", "DemoTopic",
                "as;ldmaodjaml\n" +
                "asdadassdad"));

            MailDb.Instance.LOG.ForEach(i => Console.Write("{0}\t{1}\n", i.Topic, i.Date));

            System.Console.ReadKey();

        }
    }
}
