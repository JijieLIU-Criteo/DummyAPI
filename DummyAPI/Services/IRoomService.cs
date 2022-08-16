using System;
using System.Threading.Tasks;
using DummyAPI.Models;

namespace DummyAPI.Services
{
    public interface IRoomService
    {
        #nullable enable
        Task<Room?> GetRoomAsync(Guid id);
    }
}

