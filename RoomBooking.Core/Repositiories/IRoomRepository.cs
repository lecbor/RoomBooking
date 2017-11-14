using RoomBooking.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Core.Repositiories
{
    public interface IRoomRepository
    {
        Room Get(string number);

        IEnumerable<Room> GetAll();

        void Add(Room room);

        void Update(Room room);

        void Remove(string name);
    }
}
