
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Westeros.Events.Data.Events;
using Westeros.Events.Data.Registry;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Data
{
    class Program
    {
        public static async Task Main (string[] args)
        {
            var connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EventsDB;Integrated Security=True;";
            await new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddRepositories();
                   services.AddDbContext<EventContext>(options => options.UseSqlServer(connection));
               })
               .UseHostedService<EventChecker>()
               .RunConsoleAsync();
        }
    }
}
