using JiraThing.Services.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    /// <summary>
    /// Maps friendly custom field names to their internal jira keys
    /// </summary>
    public class CustomFieldService
    {
        private Dictionary<string, string> mCustomFieldNameToID;
        private Dictionary<string, string> mCustomFieldIDToName;

        public CustomFieldService(IJiraAPIClient client)
        {
           // var foo = client.GetCustomFields().Where(p => !p.Custom).Select(p => p.Name).ToArray();
            var fields = client.GetCustomFields().Where(p => p.Custom).ToArray();

            mCustomFieldNameToID = fields.ToDictionary(p => p.Name, p => p.id);
            mCustomFieldIDToName = fields.ToDictionary(p => p.id, p => p.Name);
        }

        public string[] NamesToKeys(string fieldsCSV)
        {
            return NamesToKeys(fieldsCSV.Split(','));
        }

        public string[] NamesToKeys(string[] fields)
        {
            return fields.Select(p => mCustomFieldNameToID.GetValueOrDefault(p, p)).ToArray();
        }

        public string NameToKey(string field)
        {
            return mCustomFieldNameToID.GetValueOrDefault(field, field);
        }
    }
}
