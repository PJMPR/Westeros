using System;

namespace Westeros.Ranking.Data
{
    public class Komentarz
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public string Tekst {get; set; }
        public string Nick { get; set; }


        public Komentarz(string nick, string tekst, DateTime data)
        {
            Data = data;
            Nick = nick;
            Tekst = tekst;
        }

        public override string ToString()
        {
            return Data + Tekst + Nick;
        }

    }
}
