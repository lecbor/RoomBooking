using RoomBooking.Infrastructure.Commands.Rooms;
using RoomBooking.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Handlers.Rooms
{
    public class CreateRoomHandler : ICommandHandler<CreateRoom>
    {
        private IRoomService _roomservice;

        public CreateRoomHandler(IRoomService roomService)
        {
            _roomservice = roomService;
        }
        public async Task HandleAsync(CreateRoom command)
        {
            await _roomservice.RegisterAsync(command.Name, command.RoomNumber, command.Lectern, command.VotingSystem,
                    command.SoundSystem, command.MagneticWall, command.Computer, command.InterpretationService,
                    command.BrainstormingWall, command.LEDWall, command.Microphone, command.Multiphone, command.LCDScreen,
                    command.Flipchart, command.WhiteScreen, command.Videoconference, command.Projector);
        }
    }
}
