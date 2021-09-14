using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEvents.Data;
using SportEvents.Models;

namespace SportEvents.Data
{
    public static class DataGenerator
    {
        public static void DataSeed(this IApplicationBuilder app)
        {

            using var serviceScope = app.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<EventContext>();

            if (context.Events.Any())
            {
                return;
            }

            context.Events.Add(
                new Event(1, "Carolina Panthers", "New York Jets", DateTime.Now, DateTime.Now.AddHours(2)));

            context.SaveChanges();
        }
    }
}
