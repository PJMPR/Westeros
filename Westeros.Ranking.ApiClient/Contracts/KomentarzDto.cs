using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Ranking.ApiClient.Contracts
{
    public class KomentarzDto
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public string Tekst { get; set; }
        public string Nick { get; set; }
        public int resourceId { get; set; }
        public string resourceName { get; set; }

        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(Data)}: {Data}, {nameof(Tekst)}: {Tekst}, {nameof(Nick)}: {Nick}, {nameof(resourceId)}: {resourceId}, {nameof(resourceName)}: {resourceName}";
        }
    }
}
