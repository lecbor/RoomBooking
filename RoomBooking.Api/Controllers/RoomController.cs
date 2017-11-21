using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Infrastructure.DTO;
using RoomBooking.Infrastructure.Services;
using RoomBooking.Infrastructure.Commands.Rooms;
using RoomBooking.Infrastructure.Commands;

namespace RoomBooking.Api.Controllers
{
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomservice;
        private readonly ICommandDispacher _commandDispatcher;

        public RoomController(IRoomService roomService, ICommandDispacher commandDispacher)
        {
            _roomservice = roomService;
            _commandDispatcher = commandDispacher;
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> Get(string number)
        { 
            var room = await _roomservice.GetAsync(number);
            if (room == null)
            {
                return NotFound();
            }

            return Json(room);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateRoom command)
        {
            await _commandDispatcher.DispatchAsync(command);

             /*
            await _roomservice.RegisterAsync(command.Name, command.RoomNumber, command.Lectern, command.VotingSystem, 
            command.SoundSystem, command.MagneticWall, command.Computer, command.InterpretationService,
            command.BrainstormingWall, command.LEDWall, command.Microphone, command.Multiphone, command.LCDScreen, 
            command.Flipchart, command.WhiteScreen, command.Videoconference, command.Projector);
            */

            return Created($"room/{command.RoomNumber}", new object());
        }

    }
}
