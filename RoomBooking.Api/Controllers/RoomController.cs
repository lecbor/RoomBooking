using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Infrastructure.DTO;
using RoomBooking.Infrastructure.Services;
using RoomBooking.Infrastructure.Commands.Rooms;

namespace RoomBooking.Api.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomservice;

        public RoomController(IRoomService roomService)
        {
            _roomservice = roomService;
        }

        [HttpGet("{number}")]
        public async Task<RoomDTO> Get(string number)
            => await _roomservice.GetAsync(number);

        [HttpPost("")]
        public async Task Post([FromBody]Create request)
        {
           await _roomservice.RegisterAsync(request.Name, request.RoomNumber, request.Lectern, request.VotingSystem, 
                request.SoundSystem, request.MagneticWall, request.Computer, request.InterpretationService,
                request.BrainstormingWall, request.LEDWall, request.Microphone, request.Multiphone, request.LCDScreen, 
                request.Flipchart, request.WhiteScreen, request.Videoconference, request.Projector);
        }

    }
}
