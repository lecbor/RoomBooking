﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Tests.EndToEnd.Helpers
{
    public class LdapConfig
    {
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public int ServerPortSsl { get; set; }
        public string BaseDn { get; set; }
        public string RootUserDn { get; set; }
        public string RootUserPassword { get; set; }
    }
}
