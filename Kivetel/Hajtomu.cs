using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class Hajtomu : IKomponens
    {
        int toloero;

        public Hajtomu(int toloero)
        {
            this.toloero = toloero;
        }

        public int Teljesitmeny { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Allapot => throw new NotImplementedException();

        public void Aktival()
        {
            throw new NotImplementedException();
        }

        public void Deaktival()
        {
            throw new NotImplementedException();
        }
    }
}
