using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvents.Entities
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        private Event() { }
        public Event(string homeTeam, string awayTeam, DateTime startTime)
        {
            Home = homeTeam;
            Away = awayTeam;
            StartTime = startTime;
        }
    }
}
