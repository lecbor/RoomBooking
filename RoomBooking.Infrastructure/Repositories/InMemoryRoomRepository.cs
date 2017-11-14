using RoomBooking.Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Core.Domain;

namespace RoomBooking.Infrastructure.Repositories
{
    public class InMemoryRoomRepository : IRoomRepository
    {
        private static ISet<Room> _rooms = new HashSet<Room>
        {
            new Room("Leasure Area", "101",false,false,true,false,true,false,false,false,false,false,true,false,false,false,false),
            new Room("", "818",false,false,true,true,true,false,true,false,false,false,true,true,true,true,false),
            new Room("", "819",false,false,true,true,true,false,true,false,false,false,true,true,true,false,false)
        };

        public void Add(Room room)
        {
            _rooms.Add(room);
        }

        public Room Get(string number)
            => _rooms.SingleOrDefault(x => x.RoomNumber == number);

        public IEnumerable<Room> GetAll()
            =>_rooms;
        
        public void Remove(string name)
        {
            var room = Get(name);
            _rooms.Remove(room);
        }

        public void Update(Room room)
        {
            //var newRoom = Get(room);
            //_rooms.Remove(room);
        }
    }
}
