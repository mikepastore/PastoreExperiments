using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JiraThing.Services.Jira
{
    public interface IJiraActivityFeedService
    {
        XmlDocument GetFeedForItem(string key);
        XmlDocument GetFeedForUser(string user);
        XmlDocument GetFeedForProject(string project);
    }

    class CachedActivityFeedService : IJiraActivityFeedService
    {
        private LocalCacheService mCacheService;
        private IJiraActivityFeedService mActivityFeedService;

        public CachedActivityFeedService(LocalCacheService cacheService, JiraActivityFeedService activityFeedService)
        {
            mCacheService = cacheService;
            mActivityFeedService = activityFeedService;
        }

        public XmlDocument GetFeedForItem(string key)
        {
            return mCacheService.GetOrLoadXMLDocument("item=" + key, () => mActivityFeedService.GetFeedForItem(key));
        }

        public XmlDocument GetFeedForUser(string user)
        {
            return mCacheService.GetOrLoadXMLDocument("user=" + user, () => mActivityFeedService.GetFeedForUser(user));
        }

        public XmlDocument GetFeedForProject(string project)
        {
            return mCacheService.GetOrLoadXMLDocument("project=" + project, () => mActivityFeedService.GetFeedForProject(project));
        }
    }

    class JiraActivityFeedService : SimpleWebClient, IJiraActivityFeedService
    {
        public JiraActivityFeedService(string user, string pwd) : base(user, pwd, @"https://accelaeng.atlassian.net") { }

        public XmlDocument GetFeedForItem(string key)
        {
            return GetFeed(String.Format("issue-key+IS+{0}", key));
        }

        public XmlDocument GetFeedForUser(string user)
        {
            return GetFeed(String.Format("user+IS+{0}", user));
        }

        public XmlDocument GetFeedForProject(string project)
        {
            return GetFeed(String.Format("key+IS+{0}", project));
        }

        private XmlDocument GetFeed(string filter)
        {
            var xml = this.Get(String.Format("activity?maxResults=90000&streams={0}&providers=issues", filter));
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc;
        }

    }


}
