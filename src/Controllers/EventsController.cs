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
        private readonly ICommandDataClient _commandDataClient;
        public EventsController(
            IEventRepository repo, 
            IMapper mapper, 
            ICommandDataClient commandDataClient)
        {
            _repo = repo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _repo.GetAllEvents();

            return Ok(events);

        }

        [HttpGet]
        [Route("{id}", Name = "Event")]
        public IActionResult GetEventById(int id)
        {
            var sportEvent = _repo.GetEventById(id);

            if (sportEvent == null)
            {
                return BadRequest();
            }
            else
            {
                var eventResponse = _mapper.Map<EventResponseDTO>(sportEvent);

                return Ok(eventResponse);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody]EventRequestDTO e)
        {
            var newEvent = _mapper.Map<Event>(e);
            _repo.CreateEvent(newEvent);
            _repo.SaveChanges();

            try
            {
                var eventResponse = _mapper.Map<EventResponseDTO>(newEvent);
                Console.WriteLine("sending request to command service.");
                await _commandDataClient.SendEventToCommandAsync(eventResponse);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            if(!_repo.SaveChanges())
            {
                return BadRequest();
            } 
            else
            {
                return CreatedAtRoute("Event", new EventResponseDTO { Home = e.Home, Away = e.Away, StartTime = DateTime.Now }, e);
            }

        }
    }
}
