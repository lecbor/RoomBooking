using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RoomBooking.Infrastructure.Settings;

namespace RoomBooking.Tests.EndToEnd.Helpers
{


    public class TestsConfig
    {
        public static LdapConfig LdapServer { get; private set; }
        public const string DefaultObjectClass = "liam.local";
        public const string DefaultPassword = "Server20123";

        static TestsConfig()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            var ldapServerConfigurationSection = configuration.GetSection(nameof(LdapServerConfiguration));
            var ldapServerConfiguration = new LdapServerConfiguration;
            ldapServerConfigurationSection.Bind(ldapServerConfiguration);
            LdapServer = ldapServerConfiguration.GetSettings();
        }
    }
}
