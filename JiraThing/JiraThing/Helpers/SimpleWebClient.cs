using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    class SimpleWebClient
    {
        private string mUser;
        private string mPassword;
        private string mAPIUrl;

        public SimpleWebClient(string user, string pwd, string apiURL)
        {
            mUser = user;
            mPassword = pwd;
            mAPIUrl = apiURL;
        }

        protected string Get(string action)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Authorization", "Basic " + Utility.Base64Encode(mUser + ":" + mPassword));
                wc.Headers.Add("Content-Type", "Application/json");

                try
                {
                    var text = wc.DownloadString(mAPIUrl + "/" + action);
                    return text;
                }
                catch(System.Net.WebException wex)
                {
                    using(var r = wex.Response.GetResponseStream())
                    {
                        using(var sr = new StreamReader(r))
                        {
                            var message = sr.ReadToEnd();
                            throw new Exception(String.Format("Status {0}:{1}", r.ToString(), message));
                        }
                    }
                }

            }
        }

        protected T Get<T>(string action)
        {
            var json = Get(action);
            return JSONHelper.FromJSON<T>(json);
        }
    }
}
