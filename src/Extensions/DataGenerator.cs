using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEvents.Data;
using SportEvents.Entities;

namespace SportEvents.Extensions
{
    public static class DataGenerator
    {
        public static void DataSeed(this IApplicationBuilder app, bool isProd)
        {

            using var serviceScope = app.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<EventContext>();

            if (isProd)
            {
                context.Database.Migrate();
            }

            if (context.Events.Any())
            {
                return;
            }

            context.Events.Add(
                new Event("Carolina Panthers", "New York Jets", DateTime.Now));

            context.SaveChanges();
        }
    }
}
