using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using LegMan.Data;
using System.IO;

namespace AgendaMinutesServiceLib
{
    public class yolo
    {
       

         public static string Foo()
        {
            var connectionStrings = new Dictionary<string,string>();
            connectionStrings.Add("ServiceDataLayer",  ConfigurationManager.AppSettings["ServiceSQLConnection"]);

            var client = new LegMan.Data.DataAccess("PastoreVM", connectionStrings);

            var mtg = client.Meeting.SelectMeeting<LMMeeting>(null,null);
            client.MapObject(mtg.First(), "DepartmentID");
            
            

            return "YOLO";
        
           // return CodeGenerator.GenerateEnumWebAPIController(enumTables[0]);
           

           // return sb.ToString();
        }
    }

  
    public class Lookup
    {
        public long ID { get; set; }
        public string Name { get; set; }

        [Newtonsoft.Json.JsonIgnoreAttribute]
        public bool NeedsToBeResolved {get;set;}

        public static Lookup FromEnum<TEnum>(TEnum value)
        {
            return new Lookup
            {
                ID = Convert.ToInt64(value),
                Name = Enum.GetName(typeof(TEnum), value)
            };
        }

        public static Lookup[] FromEnums<TEnum>()
        {
            var ret = new List<Lookup>();
            foreach(TEnum enumValue in typeof(TEnum).GetEnumValues())
            {
                ret.Add(Lookup.FromEnum<TEnum>(enumValue));
            }

            return ret.ToArray();
        }
    }

    public enum FOO
    {
        AA = 1,
        BB = 2
    }
}



