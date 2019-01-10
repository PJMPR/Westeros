
using System.ComponentModel.DataAnnotations;

namespace Westeros.Ranking.Data.Model
{
    public class Dieta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DietaId { get; set; }
        [Range(0,double.MaxValue)]
        public int IloscOdwiedzin { get; set; }
    }
}