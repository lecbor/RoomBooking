using RoomBooking.Core.Domain;
using RoomBooking.Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Infrastructure.DTO;
using AutoMapper;

namespace RoomBooking.Infrastructure.Services
{
    public class RoomSerivce : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomSerivce(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }



        public async Task<RoomDTO> GetAsync(string number)
        {
            var room = await _roomRepository.GetAsync(number);

            return _mapper.Map<Room,RoomDTO>(room);
        }

        public async Task RegisterAsync(string name, string number, bool lectern, bool voting, bool sound,
                            bool magnetic, bool computer, bool interpreter, bool brain, bool led,
                            bool microphone, bool multiphone, bool lcd, bool flipchart, bool whitescren, 
                            bool videoconference, bool projector)
        {
            var room = await _roomRepository.GetAsync(number);

            if(room!= null)
            {
                throw new Exception($"Room with number {number} already exists");
            }

            room = new Room(name, number, lectern, voting, sound,
                            magnetic, computer, interpreter, brain, led,
                            microphone, multiphone, lcd, flipchart, whitescren,
                            videoconference, projector);

            await _roomRepository.AddAsync(room);
        }
    }
}
