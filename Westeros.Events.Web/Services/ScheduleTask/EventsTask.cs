using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;
using Westeros.Events.Web.Services.Events;
using Westeros.Events.Web.Services.Messages;

namespace ASPNETCoreScheduler.Scheduler
{
    public class EventsTask : ScheduledProcessor
    {

        public EventsTask(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        protected override string Schedule => "*/2 * * * *";//Runs every 2 minutes

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            new CheckRecipes(
                serviceProvider.GetService<IGenericRepository<Recipe>>(),
                serviceProvider.GetService<IGenericRepository<Profile>>(),
                serviceProvider.GetService<EventSender>(),
                serviceProvider.GetService<IGenericRepository<IMessage>>(),
                serviceProvider.GetService<IGenericRepository<LogRecord>>(),
                serviceProvider.GetService<ILinkGenerator>(),
                serviceProvider.GetService<IMyMapper>()
                )
                .CheckNew();

            return Task.CompletedTask;
        }
    }
}
