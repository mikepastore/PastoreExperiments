using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaMinutesServiceLib;

namespace AMAPI
{
    public class ConnectionInfo
    {

        public int ID
        {
            get { return this.ConnectUserID; }
            set { this.ConnectUserID = value; }
        }

        public bool Connected;
        public long ConnectionID;
        public int ConnectUserID;
        public string ConnectServer;
        public string ConnectAgency;
        public UserType ConnectUserType;

        public string ConnectUserLogin;

        public string UserName;
        public string ConnectPassword;
        public string SourceAddress;

        public string UserHostAddress;
        public bool Secure;
        public string Client;

        public Version ClientVersion = new Version(1, 0, 0, 0);

        //  public ConnectType ConnectType;

        //private UserAgent moUserAgent;
        //public UserAgent UserAgent
        //{
        //    get
        //    {
        //        if (moUserAgent == null)
        //            moUserAgent = new UserAgent("unknown");
        //        return moUserAgent;
        //    }
        //    set { moUserAgent = value; }
        //}

        public string AuthorizationHeader
        {

            get
            {
                List<string> parts = new List<string>();

                switch (this.ConnectUserType)
                {
                    case UserType.NormalUser:
                        parts.Add("Basic");
                        break;
                    case UserType.WebUserPublic:
                        parts.Add("Web");
                        break;
                    case UserType.Service:
                        parts.Add("Service");
                        break;
                    default:
                        parts.Add("Unknown");
                        break;
                }

                parts.Add(this.ConnectUserLogin + "@" + this.ConnectAgency);
                parts.Add(this.ConnectPassword.HashIfNeeded());
                parts.Add(this.ConnectionID.ToString("X"));
                parts.Add(this.SourceAddress.Ne());
                parts.Add(this.Client.Ne());
                parts.Add(this.ClientVersion.ToString(4));

                return parts.Select(p => EscapeColonDelimiter(p)).StringJoin(":");

            }
        }

        public string ConnectPasswordHashed
        {
            get
            {
                if (ConnectPassword.IsNullOrEmptyOrWhitespace())
                    return string.Empty;

                return ConnectPassword.HashIfNeeded().ToUpper();
            }
        }

        private const string CAuthHeaderDelimiterEscape = "|~|";
        private string EscapeColonDelimiter(string text)
        {
            return text.Ne().Replace(":", CAuthHeaderDelimiterEscape);
        }

        public ConnectionInfo()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public string ProtocolAndHost
        {
            get
            {
                if (Secure)
                    return "https://" + this.ConnectServer;
                else
                    return "http://" + this.ConnectServer;
            }
        }
    }

}
