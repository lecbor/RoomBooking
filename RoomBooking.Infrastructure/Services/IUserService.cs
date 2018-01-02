using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task LoginAsync(string login, string password);
    }
}
