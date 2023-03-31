using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    internal class Urhajo
    {
        public string nev { get; }
        public int uresTomeg { get; } //kg

        public int aktualisTeljesitmeny { get; } //MW

        UrhajoKategoria kategoria;
        IKomponens komponensek[];
    }
}
