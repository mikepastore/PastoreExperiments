using JiraThing.Models;
using JiraThing.Services.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace JiraThing.Services
{
    public class ActivityFeedService
    {
        private IJiraActivityFeedService mActivityReader;

        public ActivityFeedService(IJiraActivityFeedService activityReader)
        {
            mActivityReader = activityReader;
        }

        public ActivityEntry[] GetActivityForItem(string key)
        {
            var feed = mActivityReader.GetFeedForItem(key);
            return GetActivityEntries(feed).ToArray();
        }

        public ActivityEntry[] GetActivityForUser(string user)
        {
            var feed = mActivityReader.GetFeedForUser(user);
            return GetActivityEntries(feed).ToArray();
        }

        public ActivityEntry[] GetActivityForProject(string project)
        {
            var feed = mActivityReader.GetFeedForProject(project);
            return GetActivityEntries(feed).ToArray();
        }

      
        private IEnumerable<ActivityEntry> GetActivityEntries(XmlDocument feed)
        {
            feed = feed.RemoveAllNamespaces();

            foreach (XmlNode entry in feed.SelectNodes("//entry"))
            {
                var maybeActivity = ParseActivity(entry);
                if (maybeActivity != null)
                    yield return maybeActivity;
            }
        }

        private ActivityEntry ParseActivity(XmlNode node)
        {
            if (node.SelectSingleNode("updated") == null)
                return null;

            var author = node.SelectSingleNode("author/name").InnerText;
            var title = node.SelectSingleNode("title").InnerText;            
            var date = DateTime.Parse(node.SelectSingleNode("updated").InnerText);

            title = Regex.Replace(title, "<[^>]+>", "");
            title = Regex.Replace(title,@"\s+"," ");

            return new ActivityEntry
            {
                Author = author,
                Description = title,
                Date = date
            };

        }
    }
}
