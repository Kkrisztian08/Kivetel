using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class KomponensNemTalalhatoKivetel : Exception
    {
        public KomponensNemTalalhatoKivetel()
        {
        }

        public KomponensNemTalalhatoKivetel(string message) : base(message)
        {
        }
    }
}
