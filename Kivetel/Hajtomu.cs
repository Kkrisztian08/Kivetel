﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class Hajtomu : IKomponens
    {
        int toloero; //MW ekvivalens

        public Hajtomu(int toloero)
        {
            this.toloero = toloero;
        }

        public int Teljesitmeny { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Allapot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
