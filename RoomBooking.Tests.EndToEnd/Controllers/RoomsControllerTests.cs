using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using RoomBooking.Api;
using RoomBooking.Infrastructure.Commands.Rooms;
using RoomBooking.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var roomNumber = "819";
            var room = await GetRoomAsync(roomNumber);
            room.RoomNumber.ShouldBeEquivalentTo(roomNumber);
        }

        [Fact]
        public async Task given_invalid_roomNumber_room_should_not_exist()
        {
            var roomNumber = "919";
            var response = await _client.GetAsync($"room/{roomNumber}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_roomNumber_room_should_be_created()
        {
            var request = new CreateRoom
            {
                Name = "",
                RoomNumber = "1001",
                Lectern = false,
                VotingSystem = true,
                SoundSystem = false,
                MagneticWall = false,
                Computer = true,
                InterpretationService = true,
                BrainstormingWall = false,
                LEDWall = false,
                Microphone = false,
                Multiphone = false,
                LCDScreen = false,
                Flipchart = false,
                WhiteScreen = false,
                Videoconference = false,
                Projector = true
             };

            var payload = GetPayload(request);
            var response = await _client.PostAsync("room",payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"room/{request.RoomNumber}");

            var room = await GetRoomAsync(request.RoomNumber);
            room.RoomNumber.ShouldBeEquivalentTo(request.RoomNumber);

        }

        private async Task<RoomDTO> GetRoomAsync(string roomNumber)
        {
            var response = await _client.GetAsync($"room/{roomNumber}");
            var respondeString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RoomDTO>(respondeString);
        }

            private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "Application/json");
        }
    }
}
