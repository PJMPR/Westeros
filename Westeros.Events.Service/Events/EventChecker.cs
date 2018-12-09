using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Westeros.Events.Data.Repositories;
using Westeros.Events.Data.Abstract;
using Westeros.Events.Data.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Westeros.Events.Data.Events
{
    public class EventChecker : BackgroundService
    {
       
        CheckRecipes _checker;
       // private readonly OrderingBackgroundSettings _settings;

        public EventChecker(IGenericRepository<Recipe> Rrepo, IGenericRepository<Profile> Prepo)
        {
            
            _checker = new CheckRecipes(Rrepo, Prepo);

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _checker.CheckNew();

                await Task.Delay( TimeSpan.FromMinutes(2),stoppingToken);
            }
        }
    }
}
