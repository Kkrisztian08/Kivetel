using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class Hajtomu : IKomponens
    {
        int toloero; //MW ekvivalens

        public Hajtomu()
        {
        }

        public Hajtomu(int toloero)
        {
            this.toloero = toloero;
        }

         public int Teljesitmeny { get;  set; }
         public bool Allapot { get;  set; }

        public void Aktival()
        {
            Teljesitmeny = toloero;
            Allapot = true;
        }

        public void Deaktival()
        {
            Teljesitmeny = 0;
            Allapot = false;
        }
    }
}
