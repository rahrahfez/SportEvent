using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEvents.Data;
using SportEvents.Contracts;

namespace SportEvents.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _repo;
        public EventsController(IEventRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _repo.GetAllEvents();

            return Ok(events);
        }
    }
}
