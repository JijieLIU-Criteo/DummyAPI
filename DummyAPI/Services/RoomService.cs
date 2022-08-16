using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DummyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly DummyDbContext _context;
        private readonly IMapper _mapper;

        public RoomService(DummyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            return _mapper.Map<Room>(entity);
        }
    }
}

