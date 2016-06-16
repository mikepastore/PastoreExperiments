using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Any2Any
{
    static class GeneralExtensions
    {
        public static T AssertNotNull<T>(this T input, string exceptionMessage) where T : class
        {
            if (input == null)
                throw new NullReferenceException(exceptionMessage);
            else
                return input;
        }
    }
}
