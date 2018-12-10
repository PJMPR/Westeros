using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Ranking.Data.Model
{
    public class Oceny
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public string Nick { get; set; }
        public string Tekst { get; set; }
        public int Ocena { get; set; }
        public int resourceId { get; set; }
        public string resourceName { get; set; }
    }
}
