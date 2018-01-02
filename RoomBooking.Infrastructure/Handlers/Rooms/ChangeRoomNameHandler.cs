using RoomBooking.Infrastructure.Commands;
using RoomBooking.Infrastructure.Commands.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Handlers.Rooms
{
    public class ChangeRoomNameHandler : ICommandHandler<ChangeRoomName>
    {
        public async Task HandleAsync(ChangeRoomName command)
        {
            await Task.CompletedTask;
        }
    }
}
