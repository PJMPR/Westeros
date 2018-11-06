using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Events.Data.Model
{
    public class LogRecord 
    {
        public int Id { get; private set; }
        public Message message;
        public String Status { get; set; }
    }
}
