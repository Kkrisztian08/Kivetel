﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class Reaktor : IKomponens
    {
        int teljesitmeny = 0;

        public Reaktor(int teljesitmeny)
        {
            this.teljesitmeny = teljesitmeny;
        }

        public int Teljesitmeny { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Allapot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Aktival()
        {
            Teljesitmeny = teljesitmeny * (-1);
            Allapot= true;
        }

        public void Deaktival()
        {
            Teljesitmeny = 0;
            Allapot = false;
        }
    }
}