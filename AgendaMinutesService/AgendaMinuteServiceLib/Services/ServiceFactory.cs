using AMAPI;
using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AgendaMinutesServiceLib
{
    class ServiceFactory
    {
        public static T Create<T>(ConnectionInfo connection)
        {
            var connectionStrings = new Dictionary<string, string>();
            connectionStrings.Add("ServiceDataLayer", ConfigurationManager.AppSettings["ServiceSQLConnection"]);

            var client = new DataAccess(connection.ConnectAgency, connectionStrings);

            var createMethod = typeof(T).GetMethod("Create", BindingFlags.Static | BindingFlags.NonPublic);
            var ret = createMethod.Invoke(null, new object[] { client });

            return (T)ret;
        }
    }
}
