using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeDeviceDto> RecipeDevices { get; set; } = new List<RecipeDeviceDto>();
    }
}
