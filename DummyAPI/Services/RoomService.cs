using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DummyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly DummyDbContext _context;
        private readonly IConfigurationProvider _configurationProvider;

        public RoomService(
            DummyDbContext context,
            IConfigurationProvider configurationProvider)
        {
            _context = context;
            _configurationProvider = configurationProvider;
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

            var mapper = _configurationProvider.CreateMapper();
            return mapper.Map<Room>(entity);
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            var query = _context.Rooms.ProjectTo<Room>(_configurationProvider);

            return await query.ToListAsync();
        }
    }
}

