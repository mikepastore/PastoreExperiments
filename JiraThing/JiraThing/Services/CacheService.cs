using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JiraThing.Services
{
    public class LocalCacheService
    {
        private DirectoryInfo mCacheDirectory;

        public LocalCacheService(string relativePath)
        {
            var root = System.Reflection.Assembly.GetExecutingAssembly().Location;
            root = Path.GetDirectoryName(root);

            mCacheDirectory = new DirectoryInfo(root + @"\" + relativePath);
            if (!mCacheDirectory.Exists)
                mCacheDirectory.Create();
        }

        public void CacheXMLDocument(string query, XmlDocument value)
        {
            var key = Utility.Base64Encode(query);

            var file = new FileInfo(String.Format("{0}/{1}.xml", mCacheDirectory.FullName, key));
            if (file.Exists)
                file.Delete();

            value.Save(file.FullName);
        }

        public XmlDocument TryGetCachedXML(string query)
        {

            var key = Utility.Base64Encode(query);

            var file = new FileInfo(String.Format("{0}/{1}.xml", mCacheDirectory.FullName, key));
            if (file.Exists && file.LastWriteTime > DateTime.Now.GetMorningTime())
            {
                var doc = new XmlDocument();
                doc.Load(file.FullName);
                return doc;
            }
            else
                return null;
        }

        public XmlDocument GetOrLoadXMLDocument(string query, Func<XmlDocument> load)
        {
            var cachedValue = TryGetCachedXML(query);
            if (cachedValue == null)
                CacheXMLDocument(query, load());

            return TryGetCachedXML(query);                
        }
    }
}
