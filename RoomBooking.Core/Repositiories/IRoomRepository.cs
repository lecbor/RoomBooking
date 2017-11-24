using RoomBooking.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Core.Repositiories
{
    public interface IRoomRepository : IRepository
    {
        Task<Room> GetAsync(string number);

        Task<IEnumerable<Room>> GetAllAsync();

        Task AddAsync(Room room);

        Task UpdateAsync(Room room);

        Task RemoveAsync(string name);
    }
}
