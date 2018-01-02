using Microsoft.Extensions.Caching.Memory;
using RoomBooking.Infrastructure.Commands;
using RoomBooking.Infrastructure.Commands.Users;
using RoomBooking.Infrastructure.Extensions;
using RoomBooking.Infrastructure.Services;
using RoomBooking.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Handlers.Users
{

    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _memorycache;
        private readonly IUserService _userService;

        public LoginHandler(IJwtHandler jwtHandler, IMemoryCache memoryCache, IUserService userService)
        {
            _jwtHandler = jwtHandler;
            _memorycache = memoryCache;
            _userService = userService;
        }
        public async Task HandleAsync(Login command)
        {
            await _userService.LoginAsync(command.UserLogin, command.Password);
            //var user = await _userService.GetAsync(command.UserLogin); 
            //get role ???
            var role = "user";
            var jwt = _jwtHandler.CreateToken(command.UserLogin, role);
            _memorycache.SetJwt(command.TokenId, jwt);
        }
    }


}
