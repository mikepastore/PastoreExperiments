using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMinutesServiceLib
{
    public class JSONHelper
    {
        /// <summary>
        /// Uses Newtonsoft to serialize to json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ToJson<T>(T obj, string agencyTimeZone = "", bool useLegacyTimeSerialization = false)
        {

            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            };
            settings.Converters.Add(new JsonTimeConverter());
            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, settings);
        }

        /// <summary>
        /// Uses Newtonsoft
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static T FromJSON<T>(string json)
        {

            try
            {
                Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                };
                settings.Converters.Add(new JsonTimeConverter());
                settings.Converters.Add(new JsonLookupConverter());
                settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, settings);


            }
            catch (Exception ex)
            {
                throw new Exception("Unable to deserialize json", ex);
            }

        }

        //note - this function can't be named the same as the one above 
        public static object FromJSONString(string json, Type type)
        {
            try
            {
                Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                };
                // settings.Converters.Add(new JsonTimeConverter(null, false));
                settings.Converters.Add(new JsonLookupConverter());
                return Newtonsoft.Json.JsonConvert.DeserializeObject(json, type, settings);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to deserialize json", ex);
            }
        }

        public static object FromJSONLateBound(Type oType, string json)
        {
            throw new NotImplementedException();
            // return M2Common.ReflectionHelper.InvokeLateBoundGeneric(new JSONHelper(), "FromJSON", oType, new object[] { json });
        }

        public static T Copy<T>(T original)
        {

            string json = ToJson(original);
            T copiedItem = FromJSON<T>(json);
            return copiedItem;

        }


    }

    class JsonTimeConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.Value == null)
                    return null;

                string dateStr = reader.Value as string;
                if (dateStr != null)
                    return reader.Value.ToString().TryParseDate().ToLocalTime();

                return ((DateTime)reader.Value).ToLocalTime();

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to read Date from JSON: " + reader.Path, ex);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                //expect time to be local, convert to utc
                DateTime localTime = (DateTime)value;

                //make sure time really is local. Times returned by the old API will have kind=utc even though they are local, and times returned by the new API will have kind=unspecified.
                localTime = new DateTime(localTime.Year, localTime.Month, localTime.Day, localTime.Hour, localTime.Minute, localTime.Second, localTime.Millisecond, DateTimeKind.Local);

                if (localTime.IsValid())
                {
                    writer.WriteValue(localTime.ToUniversalTime().ToString("o"));
                }
                else
                {
                    writer.WriteValue("");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to write Date to JSON: " + writer.Path, ex);
            }

        }
    }

    class JsonLookupConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Lookup));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            //if the Value property is empty, this is probably a full json object

            if (reader.Value == null)
            {
                JsonSerializer plainSerializer = new JsonSerializer();
                return plainSerializer.Deserialize(reader, objectType);

            }

            //if value is a number, assume its the id
            //otherwise assume its a name. 
            string json = reader.Value.ToString();
            long longValue = json.TryParseLong(0);
            if (longValue != 0)
            {
                return new Lookup
                {
                    ID = longValue,
                    NeedsToBeResolved = true
                };
            }
            else
            {
                return new Lookup
                {
                    Name = json,
                    NeedsToBeResolved = true
                };
            }

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //not used
            throw new NotImplementedException();
        }

    }

}
