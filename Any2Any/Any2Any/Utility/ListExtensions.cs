using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Any2Any
{
    public static class ListExtensions
    {
        /// <summary>
        /// Null to Empty. Returns an empty array if null is passed in
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> Ne<T>(this IEnumerable<T> list)
        {
            return list ?? new T[] { };
        }

        public static string StringJoin(this IEnumerable<string> text, string delimiter=",")
        {
            return String.Join(delimiter, text.ToArray());
        }

        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> list) where T:class 
        {
            return list.Where(p => p != null);
        }

        public static TReturn[] SelectArray<T,TReturn>( this IEnumerable<T> list,
                                                        Func<T,TReturn> transform)
        {
            return list.Select(transform).ToArray();
        }

        public static bool IsEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }
    }
}
