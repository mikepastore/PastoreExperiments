using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services.Jira
{
    class CSVOutputService
    {
        private FriendlyStringService mFriendlyStringService;
        public CSVOutputService(FriendlyStringService friendlyStringService)
        {
            mFriendlyStringService = friendlyStringService;
        }

        public string OutputToCSV<T>(IEnumerable<T> items)
        {
            StringBuilder sb = new StringBuilder();

            var type = typeof(T);

            string[] fieldNames = type.GetProperties().Select(p => p.Name).ToArray();

            sb.Append(fieldNames.StringJoin(",")).AppendLine();

            foreach (var item in items)
                sb.AppendLine(fieldNames.Select(
                    p => mFriendlyStringService.GetFriendlyString(type.GetProperty(p).GetValue(item))).StringJoin(","));


            return sb.ToString();

        }

    }
}
