using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEvents.Data;
using SportEvents.Contracts;
using SportEvents.Models;
using SportEvents.Entities;
using AutoMapper;

namespace SportEvents.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;
        public EventsController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _repo.GetAllEvents();

            return Ok(events);
        }
        [HttpGet]
        [Route("{id}", Name = "Event")]
        public IActionResult GetEventById(int id)
        {
            var sportEvent = _repo.GetEventById(id);

            return Ok(sportEvent);
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody]EventRequestDTO e)
        {
            var newEvent = _mapper.Map<Event>(e);
            _repo.CreateEvent(newEvent);
            if(!_repo.SaveChanges())
            {
                return BadRequest();
            } else
            {
                return CreatedAtRoute("Event", new EventResponseDTO { Home = e.Home, Away = e.Away, StartTime = DateTime.Now }, e);
            }

        }
    }
}
