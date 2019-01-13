using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreScheduler.Scheduler;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Westeros.Events.Data.Registry;
using Westeros.Events.Data.Repositories;
using Westeros.Events.Web.Services.Events;
using Westeros.Events.Web.Services.Messages;

namespace Westeros.Events.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IHostedService, EventsTask>();
            //services.AddSingleton<IHostedService, MailServerTask>();
            services.AddAutoMapper();

            services.AddEventApiClient(Configuration);
            services.AddEventService(Configuration);
            services.AddRepositories();  
            services.AddMvc();

            //services.AddContext(Configuration);
            var connection=Configuration.GetConnectionString("demo");
            // @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EventsDB;Integrated Security=True;";
             services.AddDbContext<EventContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            //app.ApplicationServices.GetService<IMailSerwer>();
           // app.ApplicationServices.GetService<IEventSender>();
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
