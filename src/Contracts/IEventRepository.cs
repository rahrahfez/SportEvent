using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEvents.Models;
using SportEvents.Entities;

namespace SportEvents.Contracts
{
    public interface IEventRepository
    {
        bool SaveChanges();
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
        void CreateEvent(Event e);
    }
}
