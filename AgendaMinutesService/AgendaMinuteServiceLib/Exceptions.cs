using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMinutesServiceLib
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string recordType, object id)
            : base("The " + recordType + " with ID " + id + " was not found.")
        {

        }
    }
}
