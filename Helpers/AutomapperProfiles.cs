using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEvents.Entities;
using SportEvents.Models;

namespace SportEvents.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<EventRequestDTO, Event>();
        }
    }
}
