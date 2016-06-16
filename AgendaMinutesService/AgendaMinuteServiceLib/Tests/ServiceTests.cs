using AMAPI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMinutesServiceLib.Tests
{
    [TestFixture]
    public class ServiceTests
    {

        private ConnectionInfo GetConnectionInfo()
        {
            return new ConnectionInfo
            {
                ConnectAgency = "PastoreVM",
                ConnectUserType = UserType.NormalUser,
                ConnectUserLogin = "admin",
                ConnectPassword = "admin"
            };
        }

        [TestCase]
        public void TestFields()
        {
            var svc = MeetingService.Create(GetConnectionInfo());
            
            var mtg = svc.Get(1002, new string[]{});
            Assert.IsNotNull(mtg.MeetingID);
            Assert.IsNotNull(mtg.MeetingDate);
            Assert.IsNotNull(mtg.MeetingLocation);
            Assert.IsNotNull(mtg.MeetingLocation.MeetingLocationID);
            Assert.IsNull(mtg.Department);

            mtg = svc.Get(1002, new string[] { "Department", "MeetingLocation" });
            Assert.IsNull(mtg.MeetingType);
            Assert.IsNull(mtg.MeetingCancelNotice);
            Assert.IsNotNull(mtg.MeetingLocation);
            Assert.IsNotNull(mtg.Department.DepartmentName);

            mtg = svc.Get(1002, new string[] { "Department.UpdatedByUser.UserLogin" });
            Assert.IsNotNull(mtg.Department.UpdatedByUser.UserLogin);


        }
    }
}
