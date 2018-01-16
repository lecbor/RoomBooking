using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;
using RoomBooking.Infrastructure.Repositories;
using RoomBooking.Core.Domain;
using AutoMapper;

namespace RoomBooking.Infrastructure.Services
{
    public class RoomProvider : IRoomProvider
    {
        private readonly IMemoryCache _cache;
        private readonly InMemoryRoomRepository _repository;
        private readonly static string CacheKey = "rooms";

        public RoomProvider( IMemoryCache cache, InMemoryRoomRepository repository)
        {
            _cache = cache;
            _repository = repository;
        }
        public async Task<IEnumerable<RoomDTO>> BrowseAsync()
        {
            var rooms = _cache.Get<IEnumerable<RoomDTO>>(CacheKey);
            if (rooms == null)
            {
                //rooms = await GetAllAsync();
                var rooms2 = await _repository.GetAllAsync();
                var roomsDTO = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(rooms2);
                _cache.Set(CacheKey, roomsDTO);
            }
            return rooms;
        }
    }
}
