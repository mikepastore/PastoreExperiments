using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing.Services
{
    class FriendlyStringService
    {
        public string GetFriendlyString(object o)
        {
            if (o == null)
                return String.Empty;

            if (o is float)
                return GetFriendlyString((float)o);
            if (o is double)
                return GetFriendlyString((float)o);
            if (o is decimal)
                return GetFriendlyString((float)o);
            if (o is TimeSpan)
                return GetFriendlyString((TimeSpan)o);
            if (o is DateTime)
                return GetFriendlyString((DateTime)o);

            return o.ToString();
        }

        private string GetFriendlyString(float number)
        {
            return number.ToString("0.0");

        }
        private string GetFriendlyString(TimeSpan ts)
        {
            return GetFriendlyString((float)ts.TotalHours);
        }

        private string GetFriendlyString(DateTime date)
        {
            return date.ToString("yyyy/M/d");
        }
    }
}
