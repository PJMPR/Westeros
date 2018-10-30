using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Events.Data
{
    class Message
    {
        /*Message name*/
        public string Name { get; set; }
        /*date of release*/
        public string Date{ get; set; }
        /*person publishing*/
        public string Author { get; set; }

        public int Id{ get; set; }

        public string Topic { get; set; }

        public string Content { get; set; }

    }
}
