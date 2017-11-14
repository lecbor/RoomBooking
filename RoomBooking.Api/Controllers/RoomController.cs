using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Infrastructure.DTO;
using RoomBooking.Infrastructure.Services;

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
        public RoomDTO Get(string number)
            => _roomservice.Get(number);

    }
}
