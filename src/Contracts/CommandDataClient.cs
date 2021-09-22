using SportEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvents.Contracts
{
    public interface ICommandDataClient
    {
        Task SendEventToCommandAsync(EventResponseDTO eventResponseDTO);
    }
}
