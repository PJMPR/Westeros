using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Ranking.Data
{
    public class Komentarz
    {
        private DateTime data;
        private string tekst;
        private string nick;

        public Komentarz(string nick, string tekst, DateTime data)
        {
            this.data = data;
            this.nick = nick;
            this.tekst = tekst;
        }

        public override string ToString()
        {
            return data.ToString() + tekst + nick;
        }
    }
}
