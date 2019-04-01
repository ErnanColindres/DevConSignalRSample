using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevConSignalRSampleDataAccessLayer.Context;
using DevConSignalRSampleDataAccessLayer.Repositories.Interfaces;
using DevConSignalRSampleDataAccessLayer.Repositories;
using DevConSignalRBusinessAccessLayer.Services.Interfaces;
using DevConSignalRBusinessAccessLayer.Services;
using Microsoft.AspNetCore.SignalR;
using DevConSignalRSample.Hubs;

namespace DevConSignalRSample
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Register Connection string
            var connString = _configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<MainDbContext>(_ => _.UseSqlServer(connString));

            //Register Repository
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();

            //Register Services
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IVoteService, VoteService>();

            services.AddMvc();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseSignalR(routes =>
            {
                routes.MapHub<VoteHub>("/voteHub");
            });
        }
    }
}
