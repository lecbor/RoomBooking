using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RoomBooking.Infrastructure.Commands;
using RoomBooking.Infrastructure.Commands.Users;
using RoomBooking.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace RoomBooking.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public LoginController(ICommandDispatcher commandDispatcher,
            IMemoryCache cache) 
            : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }   
    }
}
