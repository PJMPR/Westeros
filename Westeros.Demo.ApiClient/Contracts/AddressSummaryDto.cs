namespace Westeros.Demo.ApiClient.Contracts
{
    public class AddressSummaryDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string LocalNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
