using RoomBooking.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Services
{
    public interface IRoomProvider : IService
    {
        Task<IEnumerable<RoomDTO>> BrowseAsync();
    }
}
