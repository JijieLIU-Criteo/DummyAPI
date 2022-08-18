using DummyAPI.Models;
using DummyAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<Collection<Room>>> GetRooms()
        {
            var rooms = await _roomService.GetRoomsAsync();

            var collection = new Collection<Room>
            {
                Values = rooms.ToList()
            };

            return collection;
        }

        #nullable enable
        [HttpGet("{id}")]
        public async Task<ActionResult<Room?>> GetRoom(Guid id)
        {
            var room = await _roomService.GetRoomAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

    }
}
