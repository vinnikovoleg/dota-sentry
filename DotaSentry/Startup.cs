using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.Builders;
using DotaSentry.Client.Business;
using DotaSentry.Client.Business.DataAccess;
using DotaSentry.Client.Business.DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sentry;

namespace DotaSentry
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Data Access
            services.AddScoped<IMatchesRepository, MatchesRepository>();
            services.AddScoped<IHeroesRepository, HeroesRepository>();
            services.AddScoped<JsonClient>();
            services.AddScoped(provider => new JsonSerializerSettings());

            // Services
            services.AddSingleton<IMemoryCache, MemoryCache>();

            // Builders
            services.AddScoped<MatchesBuilder>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });

            //using (SentrySdk.Init("https://bb04ee9548974e7296fb3ba2d9f316de@sentry.io/1803217"))
            //{
            //    SentrySdk.CaptureMessage("Test");
            //    // App code
            //}
        }
    }
}
