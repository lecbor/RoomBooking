using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Core.Domain
{
    public class Room
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string RoomNumber { get; protected set; }

        public bool Lectern { get; protected set; }

        public bool VotingSystem { get; protected set; }

        public bool SoundSystem { get; protected set; }

        public bool MagneticWall { get; protected set; }

        public bool Computer { get; protected set; }

        public bool InterpretationService { get; protected set; }

        public bool BrainstormingWall { get; protected set; }

        public bool LEDWall { get; protected set; }

        public bool Microphone { get; protected set; }

        public bool Multiphone { get; protected set; }

        public bool LCDScreen { get; protected set; }

        public bool Flipchart { get; protected set; }

        public bool WhiteScreen { get; protected set; }

        public bool Videoconference { get; protected set; }

        public bool Projector { get; protected set; }


        protected Room()
        {
        }

        public Room(string name, string number, bool lectern, bool voting, bool sound,
                    bool magnetic, bool computer, bool interpreter, bool brain, bool led,
                    bool microphone, bool multiphone, bool lcd, bool flipchart, bool whitescren,
                    bool videoconference, bool projector)
        {
            Id = Guid.NewGuid();
            Name = name;
            RoomNumber = number;
            Lectern = lectern;
            VotingSystem = voting;
            SoundSystem = sound;
            MagneticWall = magnetic;
            Computer = computer;
            InterpretationService = interpreter;
            BrainstormingWall = brain;
            LEDWall = led;
            Microphone = microphone;
            Multiphone = multiphone;
            LCDScreen = lcd;
            Flipchart = flipchart;
            WhiteScreen = whitescren;
            Videoconference = videoconference;
            Projector = projector;
        }
    }
}
