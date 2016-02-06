using Jira;
using JiraThing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing
{
    static class ModelExtensions
    {
        public static string ReadField(this Issue issue, string fieldName, CustomFieldService customFieldMapper)
        {
            var key = customFieldMapper.NameToKey(fieldName);
            var text = issue.Fields.GetValueOrDefault(key);
            if (text == null)
                return null;
            else
                return text.ToString();
        }

        public static T ReadField<T>(this Issue issue, string fieldName, CustomFieldService customFieldMapper)
        {
            var json = issue.ReadField(fieldName, customFieldMapper);
            if (json == null)
                return default(T);
            else
                return JSONHelper.FromJSON<T>(json.ToString());
        }

        public static float ReadFieldFloat(this Issue issue, string fieldName, CustomFieldService customFieldMapper)
        {
            var text = issue.ReadField(fieldName,customFieldMapper);
            if (String.IsNullOrEmpty(text))
                return 0f;
            else
                return float.Parse(text);
        }
    }

}
