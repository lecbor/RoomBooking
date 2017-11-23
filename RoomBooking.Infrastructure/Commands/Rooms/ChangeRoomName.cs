using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Commands.Rooms
{
    public class ChangeRoomName : ICommand
    {
        public string OldName { get; set; }

        public string NewName { get; set; }
    }
}
