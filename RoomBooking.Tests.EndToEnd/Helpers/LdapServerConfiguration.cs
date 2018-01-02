using RoomBooking.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Tests.EndToEnd.Helpers
{
    public class LdapServerConfiguration
    {
        private readonly LdapSettings _settings;



        public LdapServerConfiguration(LdapSettings settings)
        {
            _settings = settings;

        }

        //public string ServerAddress { get; set; } = "SERV2012-DC1";
        //public int ServerPort { get; set; } = 389;
        //public int ServerPortSsl { get; set; } 
        //public string BaseDn { get; set; } = "OU=Users,OU=Sales,OU=WAW,DC=liam,DC=local";
        //public string RootUserDn { get; set; } = "CN=root,OU=Users,OU=Sales,OU=WAW,DC=liam,DC=local";
        //public string RootUserPassword { get; set; } = "Server20123";

        public LdapConfig GetSettings()
        {
            var obj = new LdapConfig
            {
                ServerAddress = _settings.ServerAddress,
                ServerPort = _settings.ServerPort,
                BaseDn = _settings.BaseDn,
                RootUserDn = _settings.RootUserDn,
                RootUserPassword = _settings.RootUserPassword
            };

            return obj;
        }
    }
}
