using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business;
using DotaSentry.Business.Builders;
using DotaSentry.Business.DataAccess;
using DotaSentry.Business.DataAccess.Json;
using DotaSentry.Business.DataAccess.Mongo;
using DotaSentry.Business.DataAccess.Steam;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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

            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

            // Data Access
            //services.AddScoped<IMatchesRepository, LiveMatchesStubRepository>();
            services.AddScoped<JsonClient>();
            services.AddScoped<TeamClient>();
            services.AddScoped<SteamFileClient>();
            services.AddScoped<SteamDotaClient>();
            services.AddScoped<HeroesRepository>();
            services.AddScoped<InventoryItemRepository>();
            services.AddScoped<MatchStatsSteamRepository>();
            services.AddScoped<LiveMatchSteamRepository>();
            services.AddScoped<HeroesRepository>();
            services.AddScoped<InventoryItemRepository>();
            services.AddScoped<ImageRepository>();
            services.AddScoped<MatchStatsSteamRepository>();
            services.AddScoped<WebApiClient>();
            services.AddScoped<LeagueRepository>();
            services.AddScoped<LiveMatchStoreRepository>();
            
            // Builders
            services.AddScoped<LiveMatchBuilder>();
            services.AddScoped<MatchStatsBuilder>();
            
            // configuration
            services.Configure<DotaSentryDatabaseSettings>(
                Configuration.GetSection(nameof(DotaSentryDatabaseSettings)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<DotaSentryDatabaseSettings>>().Value);
            services.AddSingleton(provider => new JsonSerializerSettings());
            
            // Services              
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<RemoteFileSaver>();
            services.AddScoped<LiveMatchStoreUpdateJob>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, LiveMatchStoreUpdateJob updateJob)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });
            
            updateJob.Start();
        }
    }
}