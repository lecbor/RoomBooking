using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IRoomService _roomservice;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IRoomService roomservice, ILogger<DataInitializer> logger)
        {
            _roomservice = roomservice;
            _logger = logger;

        }
        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for (var i=0;i<10;i++)
            {
                var roomName = $"room{i}";
                var random = new Random();
                var rand = random.Next(100) <= 20 ? true : false;
                tasks.Add(_roomservice.RegisterAsync(roomName, i.ToString(), rand, rand, rand, rand, rand, rand, rand, rand, rand, rand, rand, rand, rand, rand, rand));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized");
        }
    }
}
