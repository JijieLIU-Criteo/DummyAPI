using DummyAPI.Models;
using DummyAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id}", Name = nameof(GetRoom))]
        public async Task<ActionResult<Room>> GetRoom(Guid id)
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
