using AutoMapper;
using Westeros.Demo.ApiClient.Contracts;
using Westeros.Demo.Data.Model;

namespace Westeros.Demo.Web.Registry
{
    public class AutoMapperRegistry:Profile
    {
        public AutoMapperRegistry()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Address, AddressSummaryDto>();
        }
    }
}
