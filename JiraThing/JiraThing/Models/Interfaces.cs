using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraThing
{
    interface IResultCollection
    {
        int StartAt { get; set; }
        int MaxResults { get; set; }
        int Total { get; set; }
    }
}
