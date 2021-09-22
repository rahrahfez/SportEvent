using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvents.Models
{
    public class EventRequestDTO
    {
        [Required(ErrorMessage = "Home team is required.")]
        public string Home { get; set; }
        [Required(ErrorMessage = "Away team is required.")]
        public string Away { get; set; }
    }
}
