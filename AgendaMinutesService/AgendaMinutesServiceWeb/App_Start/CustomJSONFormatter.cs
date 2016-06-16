using AgendaMinutesServiceLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;

namespace AgendaMinutesServiceWeb
{

    class CustomJSONFormatter : JsonMediaTypeFormatter
    {
        public override bool CanReadType(System.Type type) { return true; }
        public override bool CanWriteType(System.Type type) { return true; }

        public override void WriteToStream(Type type, object value, Stream writeStream, Encoding effectiveEncoding)
        {
            try
            {
                var json = JSONHelper.ToJson(value);
                var writer = new StreamWriter(writeStream);
                writer.Write(json);
                writer.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing to JSON stream: " + ex.Message, ex);
            }
        }

        public override Object ReadFromStream(Type type, Stream readStream, Encoding effectiveEncoding, IFormatterLogger formatterLogger)
        {
            try
            {
                using (var reader = new StreamReader(readStream))
                {
                    return JSONHelper.FromJSONString(reader.ReadToEnd(), type);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading from JSON stream: " + ex.Message, ex);
            }
        }
    }
}