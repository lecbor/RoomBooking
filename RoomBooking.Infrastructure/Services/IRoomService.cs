using RoomBooking.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Services
{
    public interface IRoomService
    {
        RoomDTO Get(string number);

        void Register(string name, string number, bool lectern, bool voting, bool sound,
                    bool magnetic, bool computer, bool interpreter, bool brain, bool led,
                    bool microphone, bool multiphone, bool lcd, bool flipchart, bool whitescren,
                    bool videoconference, bool projector);
    }
}
