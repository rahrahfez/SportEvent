using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEvents.Contracts;
using SportEvents.Models;
using SportEvents.Entities;

namespace SportEvents.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;
        public EventRepository(EventContext eventContext)
        {
            _context = eventContext;
        }
        public void CreateEvent(Event e)
        {
            _context.Add(e);
            _context.SaveChanges();
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public Event GetEventById(int id)
        {
            var e = _context.Events.FirstOrDefault(e => e.Id == id);
            return e;
        }
    }
}
