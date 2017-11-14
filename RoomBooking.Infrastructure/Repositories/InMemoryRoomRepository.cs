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
        private static ISet<Room> _rooms = new HashSet<Room>();

        public void Add(Room room)
        {
            _rooms.Add(room);
        }

        public Room Get(string name)
            => _rooms.SingleOrDefault(x => x.Name == name);

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
