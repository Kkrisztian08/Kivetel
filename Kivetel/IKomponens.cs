using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal interface IKomponens
    {
        int Teljesitmeny { get; set; } //MW
        bool Allapot { get; set; }

        void Aktival();
        void Deaktival();
    }
}
