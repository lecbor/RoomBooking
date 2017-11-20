using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Commands.Rooms
{
    public class CreateRoom : ICommand
    {
        public string Name { get; set; }

        public string RoomNumber { get; set; }

        public bool Lectern { get; set; }

        public bool VotingSystem { get; set; }

        public bool SoundSystem { get; set; }

        public bool MagneticWall { get; set; }

        public bool Computer { get; set; }

        public bool InterpretationService { get; set; }

        public bool BrainstormingWall { get; set; }

        public bool LEDWall { get; set; }

        public bool Microphone { get; set; }

        public bool Multiphone { get; set; }

        public bool LCDScreen { get; set; }

        public bool Flipchart { get; set; }

        public bool WhiteScreen { get; set; }

        public bool Videoconference { get; set; }

        public bool Projector { get; set; }
    }
}
