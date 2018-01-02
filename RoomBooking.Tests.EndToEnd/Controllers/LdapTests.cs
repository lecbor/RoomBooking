using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RoomBooking.Tests.EndToEnd.Helpers;
using Novell.Directory.Ldap;

namespace RoomBooking.Tests.EndToEnd.Controllers
{
    public class LdapTests : ControllerTestsBase
    {
        [Fact]
        public void Bind_ForExistingEntry_ShouldWork()
        {
            TestHelper.WithLdapConnection(
                ldapConnection =>
                {
                    ldapConnection.Bind(TestsConfig.LdapServer.RootUserDn, TestsConfig.LdapServer.RootUserPassword);
                });
        }

        [Fact]
        public void Bind_WithWrongPassword_ShouldThrowInvalidCredentials()
        {
            var ldapException = Assert.Throws<LdapException>(() =>
                TestHelper.WithLdapConnection(
                    ldapConnection =>
                    {
                        ldapConnection.Bind(TestsConfig.LdapServer.RootUserDn, TestsConfig.LdapServer.RootUserPassword + "1");
                    }));
            Assert.Equal(LdapException.INVALID_CREDENTIALS, ldapException.ResultCode);
        }
    }
}
