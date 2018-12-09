using System;
using Westeros.Events.Data.Model;
using Westeros.Events.Data;

public static class MailSender
{
    public static void SendMail(Message message)
    {
        MailSerwer.Instance.SendMessage(message);
    }
}
