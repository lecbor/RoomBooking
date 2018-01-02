using Microsoft.Extensions.Configuration;
using Novell.Directory.Ldap;
using RoomBooking.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private LdapSettings _settings;

        public UserService(LdapSettings settings)
        {
            _settings = settings;
        }

        public async Task LoginAsync(string login, string password)
        {
            if (login == null)
            {
                throw new Exception("Invalid credentials");
            } 

            int ldapPort = 389;
            int ldapVersion = LdapConnection.Ldap_V3;
            String ldapHost = "SERV2012-DC1";
            String loginDN = "CN=root,OU=Users,OU=Sales,OU=WAW,DC=liam,DC=local";
            String adminPassword = "Server20123";
            String objectDN = "CN=Testowy,OU=Users,OU=Sales,OU=WAW,DC=liam,DC=local";
            String testPassword = "Password1";
            LdapConnection conn = new LdapConnection();

            try
            {
                // connect to the server
                conn.Connect(ldapHost, ldapPort);

                // authenticate to the server
                conn.Bind(ldapVersion, loginDN, adminPassword);

                LdapAttribute attr = new LdapAttribute("userPassword", testPassword);
                bool correct = conn.Compare(objectDN, attr);

                System.Console.Out.WriteLine(correct ? "The password is correct." : "The password is incorrect.\n");

                // disconnect with the server
                conn.Disconnect();
                return;
            }
            catch (LdapException e)
            {
                if (e.ResultCode == LdapException.NO_SUCH_OBJECT)
                {
                    System.Console.Error.WriteLine("Error: No such entry");
                }
                else if (e.ResultCode == LdapException.NO_SUCH_ATTRIBUTE)
                {
                    System.Console.Error.WriteLine("Error: No such attribute");
                }
                else
                {
                    System.Console.Error.WriteLine("Error: " + e.ToString());
                }
            }
            catch (System.IO.IOException e)
            {
                System.Console.Out.WriteLine("Error: " + e.ToString());
            }
            System.Environment.Exit(0);
        }
    }
    
}
