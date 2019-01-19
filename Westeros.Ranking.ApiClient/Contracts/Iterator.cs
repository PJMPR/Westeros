using System;
using System.Collections.Generic;
using System.Text;
using Westeros.Ranking.ApiClient.Contracts;

namespace Westeros.Ranking.Data.Model
{
    public class Iterator
    {
        public const string DIETA_RESOURCE_NAME = "dieta";
        public const string PRZEPIS_RESOURCE_NAME = "przepis";
        public int id { get; set; }
        public string resourcename { get; set; }
    }
}
