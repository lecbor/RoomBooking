using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Tests.EndToEnd.Helpers
{
    public class LdapOps
    {
        public static LdapEntry AddEntry()
        {
            return TestHelper.WithAuthenticatedLdapConnection(ldapConnection =>
            {
                var ldapEntry = LdapEntryHelper.NewLdapEntry();
                ldapConnection.Add(ldapEntry);
                return ldapEntry;
            });
        }

        public static LdapEntry GetEntry(string dn)
        {
            try
            {
                return TestHelper.WithAuthenticatedLdapConnection(ldapConnection => ldapConnection.Read(dn));
            }
            catch (LdapException ldapException) when (ldapException.ResultCode == LdapException.NO_SUCH_OBJECT /* not found */)
            {
                return null;
            }
        }
    }
}
