using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Westeros.Events.Data.Model
{
    public class IMessage
    {
        public int Id { get; private set; }

        [Required]
        public string To { get; set; }
        [Required]
        public string From { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Boolean ReadFlag { get; set; }
    }
}
