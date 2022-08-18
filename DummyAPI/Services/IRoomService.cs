#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DummyAPI.Models;

namespace DummyAPI.Services
{
    public interface IRoomService
    {
        #nullable restore
        Task<Room?> GetRoomAsync(Guid id);

        Task<IEnumerable<Room>> GetRoomsAsync();
    }
}

