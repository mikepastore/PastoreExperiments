using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AgendaMinutesServiceLib
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the original text if it is not null or empty. Otherwise returns the new text/
        /// </summary>
        /// <param name="text"></param>
        /// <param name="newText"></param>
        /// <returns></returns>
        public static string IfEmptyThen(this string originalText, string newText)
        {
            if (originalText.IsNullOrEmpty())
                return newText;
            else
                return originalText;
        }

        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return String.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool NotNullOrEmpty(this string str)
        {
            return !String.IsNullOrEmpty(str);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        public static bool IsNullOrEmptyOrWhitespace(this string str)
        {
            return str == null || str.Trim().Length == 0;
        }

        public static int TryParseInteger(this string str, int defaultReturn=0)
        {
            int ret;
            if (Int32.TryParse(str, out ret))
                return ret;
            else
                return defaultReturn;
        }

        public static long TryParseLong(this string str, long defaultReturn = 0)
        {
            long ret;
            if (Int64.TryParse(str, out ret))
                return ret;
            else
                return defaultReturn;
        }

        public static T ParseEnum<T>(this string str, T defaultReturn)
        {
            if (str.IsNullOrEmpty())
                return defaultReturn;

            try
            {
                return (T)Enum.Parse(typeof(T), str);
            }
            catch
            {
                return defaultReturn; 
            }
        }

        /// <summary>
        /// Hashes the string, unless it already is a hash
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HashIfNeeded(this string str)
        {
            if (str.IsHashed())
                return str;
            else
                return str.Hash();
        }

        /// <summary>
        /// Returns an MD5 hash
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Hash(this string str)
        {
            byte[] bData = null;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bResults = null;

            bData = System.Text.ASCIIEncoding.ASCII.GetBytes(str);

            //This is one implementation of the abstract class MD5.
            bResults = md5.ComputeHash(bData);

            string sResults = string.Empty;

            foreach (byte b in bResults)
            {
                sResults += string.Format("{0:X02}", b);
            }

            return sResults;
        }

        public static bool IsHashed(this string str)
        {
            if (str == null) return false;
            if (str.Length != 32) return false;
            return IsHex(str);
        }


        private static bool IsHex(string str)
        {
            foreach (char c in str)
            {
                if (!(char.IsDigit(c) || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Null to empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Ne(this string str)
        {
            return str ?? String.Empty;
        }

        public static string[] CSVToArray(this string csv)
        {
            return csv.Ne().Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        public static string[][] CSVToArray(this string csv, bool firstLineIsHeader)
        {
            IEnumerable<string> rows = csv.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (firstLineIsHeader)
                rows = rows.Skip(1);

            return rows.Select(line => line.Split(',')).ToArray();

        }

    }
}
