
using Microsoft.Extensions.Configuration;
using Westeros.UserProfile.ApiClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class UserProfileApiRegistry
    {
        /*
       public static IServiceCollection AddUserProfileClient(this IServiceCollection services, IConfiguration config)
       {

          return services.AddTransient<IUserProfileApiClient>(s => new UserProfileApiClient(config.GetSection("UserProfileApi").Value));
        }*/
    }
}
