using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Any2Any
{

    public class Node
    {
        string Data;
        Node[] Children;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Data ?? "");
            foreach (var child in Children.Ne())
                sb.Append(child.ToString());

            return sb.ToString();
        }
    }

    public class NodeService : IEntityService 
    {
        public Result TryRead(Entity e)
        {
            return Result.NotSupported();
        }

        public Result TryWrite(Entity e)
        {
            return Result.NotSupported();
        }

        public Result FillChildren(Entity e)
        {
            return Result.NotSupported();
        }

        public Result FillParents(Entity e)
        {
            return Result.NotSupported();
        }
    }
}
