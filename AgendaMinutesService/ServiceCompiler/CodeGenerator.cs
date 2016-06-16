using LegMan.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AgendaMinutesServiceLib;
using System.Text.RegularExpressions;

namespace ServiceCompiler
{
    class CodeGenerator
    {
        private static string EnumFileDestination = @"AgendaMinuteServiceLib\Enums.cs";
        private static string CRUDServiceFolder = @"AgendaMinuteServiceLib\Services\CRUD\";
        private static string WebAPIControllerFolder = @"AgendaMinutesServiceWeb\Controllers\";
        private static string ModelsFile = @"AgendaMinuteServiceLib\Models\Models.cs";

        private string[] mEnumTables;
        private string[] mInternalOnlyTables;

        public static void GenerateAll()
        {
            new CodeGenerator().DoGenerateAll();
        }

        private void DoGenerateAll()
        {
            var client = CreateClient();
            var tableUsage = Assembly.GetExecutingAssembly().ReadEmbeddedResourceAsText("TableUsage.csv").CSVToArray(firstLineIsHeader: true);
            mEnumTables = tableUsage.Where(p => p[1] == "Enum").Select(p => p[0]).ToArray();
            mInternalOnlyTables = tableUsage.Where(p => p[1] == "Internal Only").Select(p => p[0]).ToArray();

            var crudTables = tableUsage.Where(p => p[1] == "CRUD").Select(p => p[0]).ToArray();
            var modelTables = tableUsage.Where(p=> p[1] == "CRUD" || p[1] == "Child Only").Select(p=>p[0]).ToArray();

            File.WriteAllText(ResolvePath(EnumFileDestination), GenerateEnumDefinitions(client));

            foreach (var table in mEnumTables)
            {
                string fileContents = CodeGenerator.GenerateEnumWebAPIController(table);
                File.WriteAllText(ResolvePath(WebAPIControllerFolder) + table + "Controller.cs", fileContents);
            }

            foreach(var table in crudTables)
            {
                string fileContents = CodeGenerator.GenerateCRUDAPIServiceCode(table);
                File.WriteAllText(ResolvePath(CRUDServiceFolder) + table + "Service.cs", fileContents);

                fileContents = CodeGenerator.GenerateCRUDWebAPIController(table);
                File.WriteAllText(ResolvePath(WebAPIControllerFolder) + table + "Controller.cs", fileContents);
            }

            File.WriteAllText(ResolvePath(ModelsFile), GenerateModels(modelTables));
        }

        private string GenerateModels(string[] tables)
        {
            var template = Assembly.GetExecutingAssembly().ReadEmbeddedResourceAsText("AMAPIClass.txt");

            var sb = new StringBuilder();
            foreach (var table in tables)
                sb.Append(GenerateModel(table));

            template = template.Replace("CONTENTS", sb.ToString());

            return template;
        }

        private string GenerateModel(string table)
        {
            var sb = new StringBuilder();
            sb.Append("public class ").Append(table).Append(" {").AppendLine();

            var lmType = typeof(LMVote).Assembly.FindType("LM" + table);

            foreach(var prop in lmType.GetProperties())
            {
                WriteModelProperty(prop, sb, table);
            }

            sb.Append("}").AppendLine().AppendLine();

            return sb.ToString();
        }

        private void WriteModelProperty(PropertyInfo property, StringBuilder sb, string table)
        {
            string typeName = property.PropertyType.ToString();
            string propName = property.Name;

            if (propName == "MappingDefinitions")
                return;

            if(property.PropertyType.IsGenericType)
            {
                var genericParameter = property.PropertyType.GenericTypeArguments[0].Name;
                if (genericParameter.StartsWith("LM"))
                    genericParameter = genericParameter.Substring(2);

                if (typeName.Contains("Nullable"))
                    typeName = genericParameter + "?";
                else if (typeName.Contains("Generic.List"))
                {

                    //is there an enum by this name?
                    if (mEnumTables.Contains(genericParameter))
                        typeName = "AMAPI." + genericParameter;
                    else if(mInternalOnlyTables.Contains(genericParameter))
                        return;
                    else if ((property.DeclaringType.GetProperty(property.Name.TrimEnd('s') + "ID") != null) ||
(property.DeclaringType.GetProperty(property.Name + "sID") != null)
)
                    {
                        //is there a "ID" property for this list? If so we only need one
                        typeName = genericParameter;
                        propName = property.Name.TrimEnd('s');
                    }
                    else
                        typeName = "List<" + genericParameter + ">";

                }
            }


            //hack until i find another instance of the same problem
            if (table == "FileFormat" && propName == "FileFormat")
                propName = "Ext";

            sb.AppendFormat("     public {0} {1} {{ get;set; }}", typeName, propName).AppendLine();
        }

        private static DataAccess CreateClient()
        {
            var connectionStrings = new Dictionary<string, string>();
            connectionStrings.Add("ServiceDataLayer", ConfigurationManager.AppSettings["ServiceSQLConnection"]);

            var client = new LegMan.Data.DataAccess(ConfigurationManager.AppSettings["SourceAgency"], connectionStrings);
            return client;
        }
        private static string ResolvePath(string relativePath)
        {
            var folder = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var ret= folder.Parent.Parent.Parent.FullName + @"\" + relativePath;
            return ret;
        }

        private string GenerateEnumDefinitions(DataAccess client)
        {
            var template = Assembly.GetExecutingAssembly().ReadEmbeddedResourceAsText("AMAPIClass.txt");

            var sb = new StringBuilder();            
            foreach (var table in mEnumTables)
            {
                sb.Append(CodeGenerator.GenerateEnumCode(table, client));
            }

            template = template.Replace("CONTENTS", sb.ToString());
            return template;
        }

        public static string GenerateCRUDAPIServiceCode(string tableName)
        {
            var template = new StringBuilder(Assembly.GetExecutingAssembly().ReadEmbeddedResourceAsText("CRUDService.txt"));
            template.Replace("MyTable", tableName);

            string daProp = tableName;

            if(typeof(DataAccess).GetProperty(daProp) == null)
            {
                foreach(var prop in typeof(DataAccess).GetProperties())
                {
                    if (prop.PropertyType.GetMethods().Where(p => p.Name == "Select" + tableName).IsEmpty() == false)
                    {
                        daProp = prop.Name;
                        break;
                    }
                }
            }

            var keyType = typeof(DataAccess).GetProperty(daProp).PropertyType.GetMethods().FirstOrDefault(
                p=>p.Name == "Select" + tableName).GetParameters().First().ParameterType;

            if (keyType.IsGenericType)
                keyType = keyType.GetGenericArguments().First();

            template.Replace("KeyType", keyType.Name);
            template.Replace("DAProp", daProp);
            return template.ToString();
        }

        public static string GenerateEnumCode(string tableName, DataAccess client)
        {
            var method = FindSelectMethod(tableName, client, true);
            var lmType = client.GetType().Assembly.FindType("LM" + tableName);

            var clientPropertyValue = client.GetType().GetProperties().FirstOrDefault(p => p.PropertyType.IsAssignableFrom(method.DeclaringType)).GetValue(client);

            //example: client.Agenda.SelectAgendaVersion<LMAgendaVersion>(null, null);
            var list = method.DeclaringType.InvokeLateBoundGeneric(clientPropertyValue, method.Name, lmType, new object[] { null, null });

            return (string)typeof(CodeGenerator).InvokeLateBoundGeneric(null, "GenerateEnumCode", lmType, new object[] { list });
        }

        public static string GenerateEnumCode<T>(IEnumerable<T> values)
        {
            var valueType = typeof(T);
            var nameProperty = valueType.GetProperties().FirstOrDefault(p => p.Name.Contains("Name"));
            var valueProperty = valueType.GetProperties().FirstOrDefault(p => p.Name.EndsWith("ID"));

            if (nameProperty == null)
                nameProperty = valueType.GetProperties().FirstOrDefault(p => p.PropertyType == typeof(string));

            if (valueProperty == null)
                valueProperty = valueType.GetProperties().FirstOrDefault(p => typeof(int).IsAssignableFrom(p.PropertyType));

            if (valueProperty == null)
                valueProperty = valueType.GetProperties().FirstOrDefault(p => typeof(int?).IsAssignableFrom(p.PropertyType));

            return GenerateEnumCode(values, v => ((string)nameProperty.GetValue(v)), v => Convert.ToByte(valueProperty.GetValue(v)));
        }

        public static string GenerateEnumCode<T>(IEnumerable<T> values, Func<T, string> GetName, Func<T, Byte> GetValue)
        {
            var template = new StringBuilder(Assembly.GetExecutingAssembly().ReadEmbeddedResourceAsText("Enum.txt"));
            template.Replace("MyEnum", typeof(T).Name.Substring(2));

            template.Replace("MyValue",
                values.Select(p => String.Format("{0}{1}={2}", "\t", CleanupStringForCode(GetName(p)), GetValue(p))).StringJoin("," + Environment.NewLine));
            return template.ToString();
        }

        public static string GenerateEnumWebAPIController(string tableName)
        {
            var template = new StringBuilder(Assembly.GetExecutingAssembly().ReadEmbeddedResourceAsText("EnumWebAPIController.txt"));
            template.Replace("MyEnumName", tableName);
            return template.ToString();
        }

        public static string GenerateCRUDWebAPIController(string tableName)
        {
            var template = new StringBuilder(Assembly.GetExecutingAssembly().ReadEmbeddedResourceAsText("CRUDWebAPIController.txt"));
            template.Replace("MyTable", tableName);

            var lmType = typeof(LMMeeting).Assembly.FindType("LM"+tableName);
            var keyProp = lmType.GetProperty(tableName + "ID");
            Type keyType = null;
            if (keyProp == null)
            {
                //hack
                if (tableName == "FileFormat")
                    keyType = typeof(string);
                else
                    keyType = typeof(int);
            }
            else if (keyProp.PropertyType.IsGenericType)
                keyType = keyProp.PropertyType.GenericTypeArguments[0];
            else
                keyType = keyProp.PropertyType;
            
            template.Replace("KeyType", keyType.Name);
            return template.ToString();
        }

        private static MethodInfo FindSelectMethod(string tableName, object obj, bool recurse)
        {
            var objType = obj.GetType();
            var selectMethod = objType.GetMethods().FirstOrDefault(p => p.Name == "Select" + tableName);
            if (selectMethod != null)
                return selectMethod;

            if (recurse)
            {
                foreach (var property in objType.GetProperties())
                {
                    var propertyValue = property.GetValue(obj);
                    if (property != null)
                    {
                        selectMethod = FindSelectMethod(tableName, propertyValue, false);
                        if (selectMethod != null)
                            return selectMethod;
                    }
                }
            }

            return null;
        }

        private static string CleanupStringForCode(string text)
        {
            return Regex.Replace(text, @"[^\w]","");
        }

    }

}
