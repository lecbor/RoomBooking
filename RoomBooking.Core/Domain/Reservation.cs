using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Core.Domain
{
    public class Reservation
    {
        public Guid Id { get; protected set; }

        public Guid RoomId { get; protected set; }

        public Guid UserId { get; protected set; }

        public DateTime StartTime { get; protected set; }

        public DateTime EndTime { get; protected set; }

        public bool ExternalMeeting { get; protected set; }

        //TODO EQUIPMENT 
        //TODO ON BEHALF
        //TODO RECURENCE

        protected Reservation()
        {
        }

        public Reservation(Guid room, Guid user, DateTime start, DateTime end, bool external)
        {
            Id = Guid.NewGuid();
            RoomId = room;
            UserId = user;
            StartTime = start;
            EndTime = end;
            ExternalMeeting = external;
        }
    }
}
