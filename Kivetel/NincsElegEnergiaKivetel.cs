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
        static string uzenetecske;

        public NincsElegEnergiaKivetel(int hianyMerteke) : base(message: uzenetecske)
        {
            uzenetecske = $"[KIVETEL] Nincs elég teljesítmény, {uzenetecske} MW hiányzik";
            this.hianyMerteke = hianyMerteke;
        }
    }
}
