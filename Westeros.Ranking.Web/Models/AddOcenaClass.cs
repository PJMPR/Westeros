using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Westeros.Ranking.Web.Models
{
    public class AddOcenaClass
    {
        [Required]
        public string Nick { get; set; }
        [Required]
        public string Tekst { get; set; }
        [Required]
        [Range(1,5)]
        public int Ocena { get; set; }
        public string UrlElements { get; set; }
    }
}
