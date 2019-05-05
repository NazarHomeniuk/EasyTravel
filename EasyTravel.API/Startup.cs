using EasyTravel.Contracts.Interfaces.Helpers;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.HangFire.Services;
using EasyTravel.Services.BingMaps;
using EasyTravel.Services.BlaBlaCar;
using EasyTravel.Services.Bus;
using EasyTravel.Services.Helpers;
using EasyTravel.Services.Http;
using EasyTravel.Services.Railway;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyTravel.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOptions();
            services.Configure<BlaBlaCarConfig>(Configuration.GetSection("BlaBlaCar"));
            services.Configure<RailwayConfig>(Configuration.GetSection("Railway"));
            services.Configure<BusConfig>(Configuration.GetSection("Bus"));
            services.Configure<BingMapsConfig>(Configuration.GetSection("BingMaps"));
            services.Configure<HangFireConfig>(Configuration.GetSection("HangFire"));

            services.AddTransient<BlaBlaCarFinder>();
            services.AddTransient<RailwayFinder>();
            services.AddTransient<BusFinder>();
            services.AddTransient<RailwayMonitoringService>();
            services.AddTransient<BusMonitoringService>();
            services.AddTransient<BlaBlaCarMonitoringService>();
            services.AddTransient<IDateFormatter, DateFormatter>();
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<IMapsService, MapsService>();
            services.AddTransient<ILinkBuilder, LinkBuilder>();

            var connectionString = Configuration["ConnectionString:EasyTravel"];
            services.AddDbContext<DataContext>(opts => opts.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("EasyTravel.Core")));
            services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            app.UseMvc();
        }
    }
}
