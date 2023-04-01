using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class NemDeaktivalhatoKivetel : Exception
    {
        public NemDeaktivalhatoKivetel(string message) : base(message)
        {
        }
    }
}
