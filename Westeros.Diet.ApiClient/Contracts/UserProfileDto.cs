using System.Collections.Generic;
using Westeros.Diet.Data.Model;


namespace Westeros.Diet.ApiClient.Contracts
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public ICollection<EntryDto> Entries { get; set; } = new List<EntryDto>();
    }
}
