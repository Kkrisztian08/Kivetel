using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class KomponensNemFerElKivetel : Exception
    {
        IKomponens komponens;

        public KomponensNemFerElKivetel(string message, IKomponens komponens) : base(message)
        {
            this.komponens = komponens;
        }
    }
}
