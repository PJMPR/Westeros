using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Events.ApiClient.Contracts
{
    public class MessageDto
    {
        public int Id { get; private set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Boolean ReadFlag { get; set; }

    }
}
