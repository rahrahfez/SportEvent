using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportEvents.Models;

namespace SportEvents.Data
{
    public class EventContext : DbContext
    {
        public EventContext() : base() { }
        public virtual DbSet<Event> Event { get; set; }
    }
}
