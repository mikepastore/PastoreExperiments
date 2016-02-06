using Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JiraThing.Services.Jira
{
    public interface IJiraAPIClient
    {
        SearchResults Search(string[] fields, int start, int maxResults, string jql);
        Issue Get(string key);
        Field[] GetCustomFields();
    }

    class JIRAAPIClient : SimpleWebClient, IJiraAPIClient
    {
        public JIRAAPIClient(string user, string pwd) : base(user, pwd, @"https://accelaeng.atlassian.net/rest/api/2") { }
     
        public SearchResults Search(string[] fields, int start, int maxResults, string jql)
        {
            return this.Get<SearchResults>(String.Format("search?fields={0}&startAt={1}&maxResults={2}&jql={3}", 
                fields.StringJoin(","), start, maxResults, jql));
        }

        public Issue Get(string key)
        {
            return this.Get<Issue>(String.Format("issue/{0}", key));
        }


        public Field[] GetCustomFields()
        {
            return this.Get<Field[]>("field");
        }
    }

    
}
