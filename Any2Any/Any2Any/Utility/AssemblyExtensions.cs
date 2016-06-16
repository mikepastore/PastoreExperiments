using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Any2Any
{
    public static class EmbeddedResource
    {
        public static Type FindType(this Assembly assembly, string name)
        {
            return assembly.GetTypes().FirstOrDefault(p => p.Name == name);
        }

        public static string ReadEmbeddedResourceAsText(this Assembly assembly, string nameSubstring)
        {
            var fullName = assembly.GetManifestResourceNames().FirstOrDefault(p => p.Contains(nameSubstring));
            if(fullName.IsNullOrEmptyOrWhitespace())
                throw new ArgumentException("There are no resources that include the name '" + nameSubstring + "'");

            using(var stream = assembly.GetManifestResourceStream(fullName))
            {
                using(var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
