using AMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaMinutesServiceWeb
{
    public interface IConnectionInfoProvider
    {
        ConnectionInfo GetConnectionInfo();
    }

    public class HTTPContextConnectionInfoProvider : IConnectionInfoProvider 
    {

        public ConnectionInfo GetConnectionInfo()
        {
            // temporarily hard coded
            return new ConnectionInfo
            {
                ConnectAgency="PastoreVM",
                ConnectUserType = UserType.NormalUser,
                ConnectUserLogin = "admin",
                ConnectPassword = "admin"
            };
        }
    }
}