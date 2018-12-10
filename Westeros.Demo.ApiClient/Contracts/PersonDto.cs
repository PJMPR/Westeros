using System.Collections.Generic;

namespace Westeros.Demo.ApiClient.Contracts
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ICollection<AddressSummaryDto> Addresses { get; set; } = new List<AddressSummaryDto>();
    }
}
