using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Any2Any
{
    interface IConverter
    {
        Result Fill(Entity source, Entity dest);
    }

    public class FooConverter : IConverter 
    {
        public Result Fill(Entity source, Entity dest)
        {
            throw new NotImplementedException();
        }
    }

   

    public class Entity
    {
        public object Data { get; set; }
        public Entity[] Parents { get; set; }
        public Entity[] Children { get; set; }
        public string Key { get; set; }


        public T GetData<T>() where T:class 
        {
            var t = Data as T;
            return t;
        }
    }

    public enum ResultType
    {
        Unknown,
        Error,
        InsufficientData,
        NotSupported,
        Success
    }

    public class Result
    {
        public ResultType ResultType { get; set; }
        public string Message { get; set; }

        public static Result Success()
        {
            return new Result { ResultType = Any2Any.ResultType.Success };
        }    

        public static Result InsufficientData(string message)
        {
            return new Result { ResultType = ResultType.InsufficientData, Message = message };
        }

        public static Result NotSupported(string message="")
        {
            return new Result { ResultType = ResultType.NotSupported, Message = message };
        }

    }

    public interface IEntityService
    {
        Result TryRead(Entity e);
        Result TryWrite(Entity e);
        Result FillChildren(Entity e);
        Result FillParents(Entity e);
    }

    
 }
