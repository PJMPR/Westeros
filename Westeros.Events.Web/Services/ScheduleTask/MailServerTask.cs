
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;
using Westeros.Events.Web.Services.Messages;

namespace ASPNETCoreScheduler.Scheduler
{
    public class MailServerTask : ScheduledProcessor
    {
        public MailServerTask(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }
        protected override string Schedule => "*/1 * * * *";//Runs every 2 minutes
        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            new CheckMail(
               serviceProvider.GetService<IGenericRepository<MailServer>>(),
               serviceProvider.GetService <IGenericRepository < IMessage >> (),
               serviceProvider.GetService<IGenericRepository<LogRecord>> (),
               serviceProvider.GetService <IGenericRepository < Profile >> (),
               serviceProvider.GetService<IMyMapper>()      
               )
               .CheckNew();
            return Task.CompletedTask;
        }
    }
}
