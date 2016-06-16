using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Any2Any
{
    public static class ReflectionExtensions
    {

        public static object InvokeLateBoundGeneric(this Type callingType, object caller, string functionName, Type type, object[] args)
        {
            MethodInfo[] methods = callingType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            var method = methods.FirstOrDefault(p => p.Name == functionName && p.GetParameters().Count() == args.Length);
            method = method.MakeGenericMethod(type);
            return method.Invoke(caller,args);
        }

    }
}
