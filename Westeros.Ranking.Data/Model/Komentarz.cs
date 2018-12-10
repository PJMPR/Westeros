using System;

namespace Westeros.Ranking.Data.Model
{
    public class Komentarz
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public string Tekst {get; set; }
        public string Nick { get; set; }
        public int resourceId { get; set; }
        public string resourceName { get; set; }
    }
}
