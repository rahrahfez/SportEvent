using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SportEvents.Data;
using SportEvents.Extensions;
using SportEvents.Contracts;
using SportEvents.Services;
using Microsoft.EntityFrameworkCore;

namespace SportEvents
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (_env.IsProduction())
            {
                Console.WriteLine("using mssql");
                services.AddDbContext<EventContext>(opts =>
                {
                    opts.UseSqlServer(Configuration.GetConnectionString("EventsConnection"));
                });
            }
            else
            {
                Console.WriteLine("using inmemdb");
                services.AddDbContext<EventContext>(opts =>
                {
                    opts.UseInMemoryDatabase("InMemoryDB");
                });

            }

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SportEvents", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportEvents v1"));
            }

            //app.DataSeed(env.IsProduction());

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var ip = Configuration.GetValue<string>("CommandService");
            Console.WriteLine($"CommandService endpoint: {ip}.");
        }
    }
}
