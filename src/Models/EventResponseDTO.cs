using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvents.Models
{
    public class EventResponseDTO
    {
        public int Id { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public DateTime StartTime { get; set; }
    }
}
