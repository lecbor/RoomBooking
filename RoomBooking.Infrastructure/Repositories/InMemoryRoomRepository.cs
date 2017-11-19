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

        public async Task<Room> GetAsync(string number)
            => await Task.FromResult(_rooms.SingleOrDefault(x => x.RoomNumber == number));

        public async Task AddAsync(Room room)
        {
            await Task.FromResult(_rooms.Add(room));
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
            => await Task.FromResult(_rooms);
        
        public async Task RemoveAsync(string name)
        {
            var room = await GetAsync(name);
            await Task.FromResult(_rooms.Remove(room));
        }

        public async Task UpdateAsync(Room room)
        {
            await Task.CompletedTask;
            //var newRoom = Get(room);
            //_rooms.Remove(room);
        }
    }
}
