using RoomBooking.Core.Domain;
using RoomBooking.Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Infrastructure.DTO;

namespace RoomBooking.Infrastructure.Services
{
    public class RoomSerivce : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomSerivce(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomDTO Get(string number)
        {
            var room = _roomRepository.Get(number);

            return new RoomDTO
            {
                Id = room.Id,
                Name = room.Name,
                RoomNumber = room.RoomNumber,
                Lectern = room.Lectern,
                VotingSystem = room.VotingSystem,
                SoundSystem = room.SoundSystem,
                MagneticWall = room.MagneticWall,
                Computer = room.Computer,
                InterpretationService = room.InterpretationService,
                BrainstormingWall = room.BrainstormingWall,
                LEDWall = room.LEDWall,
                Microphone = room.Microphone,
                Multiphone = room.Multiphone,
                LCDScreen = room.LCDScreen,
                Flipchart = room.Flipchart,
                WhiteScreen = room.Flipchart,
                Videoconference = room.Videoconference,
                Projector = room.Projector
            };
        }

        public void Register(string name, string number, bool lectern, bool voting, bool sound,
                            bool magnetic, bool computer, bool interpreter, bool brain, bool led,
                            bool microphone, bool multiphone, bool lcd, bool flipchart, bool whitescren, 
                            bool videoconference, bool projector)
        {
            var room = _roomRepository.Get(number);

            if(room!= null)
            {
                throw new Exception($"Room with number {number} already exists");
            }

            room = new Room(name, number, lectern, voting, sound,
                            magnetic, computer, interpreter, brain, led,
                            microphone, multiphone, lcd, flipchart, whitescren,
                            videoconference, projector);

            _roomRepository.Add(room);
        }
    }
}
