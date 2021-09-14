using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvents.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Event(int id, string homeTeam, string awayTeam, DateTime startTime, DateTime endTime)
        {
            Id = id;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
