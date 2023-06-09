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

        public int Teljesitmeny { get  ; set; }
        public  bool Allapot { get ; set ; }

        public void Aktival()
        {
            if (Allapot==true)
            {
                throw new InvalidOperationException("[HIBA] Egy reaktor már fut!");
            }
            
            else if (this.teljesitmeny==0)
            {
                throw new NotSupportedException();
            }
            Teljesitmeny = teljesitmeny * (-1);
            Allapot = true;
        }

        public void Deaktival()
        {
            
            if (Allapot==false)
            {
                throw new InvalidOperationException();
            }
            Teljesitmeny = 0;
            Allapot = false;
        }
    }
}
