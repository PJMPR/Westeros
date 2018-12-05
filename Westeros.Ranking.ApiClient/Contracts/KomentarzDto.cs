using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Ranking.ApiClient.Contracts
{
    class KomentarzDto
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public string Tekst { get; set; }
        public string Nick { get; set; }
        public int resourceId { get; set; }
        public string resourceName { get; set; }
    }
}
