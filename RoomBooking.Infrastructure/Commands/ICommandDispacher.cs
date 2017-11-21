using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Commands
{
    public interface ICommandDispacher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
