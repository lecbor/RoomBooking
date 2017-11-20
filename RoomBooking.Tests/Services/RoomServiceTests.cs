using AutoMapper;
using FluentAssertions;
using Moq;
using RoomBooking.Core.Domain;
using RoomBooking.Core.Repositiories;
using RoomBooking.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RoomBooking.Tests.Services
{
    public class RoomServiceTests
    {
        [Fact]
        public async Task registerAsync_shuold_invoke_addAsync()
        {
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var mapperMock = new Mock<IMapper>();

            var roomService = new RoomSerivce(roomRepositoryMock.Object, mapperMock.Object);
            await roomService.RegisterAsync("test1", "919", false, false, true, true, true, false, true, false, false, false, true, true, true, false, false);

            roomRepositoryMock.Verify(y => y.AddAsync(It.IsAny<Room>()), Times.Once);
        }
    }
}
