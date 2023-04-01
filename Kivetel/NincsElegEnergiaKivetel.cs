using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class NincsElegEnergiaKivetel : Exception
    {
        int hianyMerteke { get; }

        public NincsElegEnergiaKivetel(int hianyMerteke)
        {
            this.hianyMerteke = hianyMerteke;

        }
    }
}
