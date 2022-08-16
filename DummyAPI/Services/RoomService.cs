using System;
using System.Linq;
using System.Threading.Tasks;
using DummyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly DummyDbContext _context;

        public RoomService(DummyDbContext context)
        {
            _context = context;
        }

        #nullable enable
        public async Task<Room?> GetRoomAsync(Guid id)
        {
            var entity = await _context.Rooms
                .SingleOrDefaultAsync(room => room.Id == id);

            if (entity == null)
            {
                return null;
            }

            return new Room
            {
                Href = null,
                Name = entity.Name,
                Rate = entity.Rate / 100.0m
            };
        }
    }
}

