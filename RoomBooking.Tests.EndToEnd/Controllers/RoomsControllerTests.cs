using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using RoomBooking.Api;
using RoomBooking.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RoomBooking.Tests.EndToEnd.Controllers
{
    public class RoomsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;


        public RoomsControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_roomNumber_room_should_exist()
        {
            // Act
            var roomNumber = "819";
            var response = await _client.GetAsync($"room/{roomNumber}");
            response.EnsureSuccessStatusCode();

            var respondeString = await response.Content.ReadAsStringAsync();
            var room = JsonConvert.DeserializeObject<RoomDTO>(respondeString);

            // Assert
            room.RoomNumber.ShouldBeEquivalentTo(roomNumber);
        }
    }
}
