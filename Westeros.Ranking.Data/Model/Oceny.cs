using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Westeros.Ranking.Data.Model
{
    public class Oceny
    {
        [Key]
        public int id { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Nick { get; set; }

        [Required]
        public string Tekst { get; set; }

        [Required]
        [Range(1,5)]
        public int Ocena { get; set; }

        public int resourceId { get; set; }
        public string resourceName { get; set; }
    }
}
