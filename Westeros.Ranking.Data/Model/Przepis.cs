using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Westeros.Ranking.Data.Model
{
    public class Przepis
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PrzepisId { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public int IloscOdwiedzin { get; set; }
    }
}