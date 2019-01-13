using System;

using System.ComponentModel.DataAnnotations;

namespace Westeros.Events.Data.Model
{
    public class MailServer
    {
        public int Id { get; private set; }

        [Required]
        public string To { get; set; }
        [Required]
        public string From { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Boolean IsNew { get; set; } = true;
    }
}
