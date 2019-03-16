using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightsExample
{
    [Flags]
    public enum RightsEnum
    {
        Read = 1,
        Write = 2,
    }
}
