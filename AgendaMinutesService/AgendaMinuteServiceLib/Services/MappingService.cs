using LegMan.Data;
using LegMan.Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMinutesServiceLib
{

 
    class MappingHelper
    {
        private DataAccess mDataAccess;
        private string[] mFields;
        private Type mDestType;

        public static TOut MapLMDataObject<TIn, TOut>(DataAccess client, TIn srcObject, string[] fields) where TIn : IEntityBase
        {
            if (fields.IsEmpty())
                fields = new string[] { "*" };

            var helper = new MappingHelper(client, typeof(TOut), fields);
            return (TOut)helper.MapLMDataObject(srcObject,typeof(TOut));
        }

        private MappingHelper(DataAccess da, Type destType, string[] fields)
        {
            mDataAccess = da;
            mDestType = destType;
            mFields = fields;
        }


        private object MapLMDataObject(IEntityBase srcObject, Type destinationType)
        {
            var destObject = Activator.CreateInstance(destinationType);

            //var pkField = GetPrimaryKeyName(srcObject);
            //MapField(srcObject, destObject, pkField, propertyDepth);

            foreach (var field in mFields)
                MapField(field, srcObject, destObject);   

            return destObject;
        }

        private void MapField(string field, object src, object dest)
        {
            var srcProperty = NavigateToProperty(src.GetType(), field);
            var destProperty = NavigateToProperty(dest.GetType(), field);

        
            var srcValue = srcProperty.Item1.GetValue(src);
            destProperty.SetValue(dest, SourceValueToDestValue(srcValue, destProperty.PropertyType));
            
        }

        private string SourceValueToDestValue(object srcValue, Type targetType)
        {
            throw new NotImplementedException();
        }

        private PropertyInfo NavigateToProperty(Type type, string path)
        {
            PropertyInfo property = null;
            foreach(var part in path.Split(new char[]{'.'}, StringSplitOptions.RemoveEmptyEntries))
            {
                if (part == "*")
                {

                }
                else
                {
                    property = type.GetProperty(part);
                    if (property != null)
                        type = property.PropertyType;
                }
            }
            return property;
        }

      
        
      
    }
}
