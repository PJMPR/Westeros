using System;
using Westeros.Events.Data;
using Westeros.Events.Data.Model;

namespace Westeros.Events.Service
{
    class Program
    {
        static void Main(string[] args)
        {
       
            MailSender.SendMail(new Message
            {
                To = "Demo8",
                From = "Demo1",
                Content = "asdada",
                Topic = "demo"
            });
            MailSender.SendMail(new Message
            {
                To = "Demo2",
                From = "Demo1",
                Content = "asdada",
                Topic = "demo"
            });
            MailSender.SendMail(new Message
            {
                To = "Demo1",
                From = "Demo4",
                Content = "asdada",
                Topic = "demo"
            });
            MailSender.SendMail(new Message
            {
                To = "Demo3",
                From = "Demo2",
                Content = "asdada",
                Topic = "demo"
            });
            MailSender.SendMail(new Message
            {
                To = "Demo1",
                From = "Demo3",
                Content = "asdada",
                Topic = "demo"
            });
            System.Console.ReadKey();

        }
    }
}
