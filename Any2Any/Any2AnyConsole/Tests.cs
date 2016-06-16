using Any2Any;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Any2AnyConsole
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void Test()
        {
            var fs = new FileSystemService();

            var file = new Entity { Key = @"C:\Program Files (x86)" };

            var result = fs.TryRead(file);
            Assert.AreEqual(ResultType.Success, result.ResultType);

            fs.FillChildren(file);
            Assert.IsTrue(file.Children.Length > 0);


            var svc = new NodeService();

            var cvt = new FooConverter();

            


        }
    }
}
