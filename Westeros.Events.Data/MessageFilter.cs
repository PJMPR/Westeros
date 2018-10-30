using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Events.Data
{
    class MessageFilter
    {
        public Message message;

        public void Filter(Message message)
        {
            /*filtrowanie wiadomosci 
             * uzywajac preferencji usera*/
            this.message = message;
        }

        public void sendToUser()
        {
            /*wysylanie wiadomosci do uzytkownika*/
        }
        public void sendToLog()
        {
            /*wysylanie do logu*/

        }
    }
}
