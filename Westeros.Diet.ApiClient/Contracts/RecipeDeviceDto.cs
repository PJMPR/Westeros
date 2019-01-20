using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class RecipeDeviceDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int DeviceId { get; set; }
        public RecipeDto Recipe { get; set; }
        public DeviceDto Device { get; set; }
    }
}
