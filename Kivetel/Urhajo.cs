using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    class Urhajo
    {
        public string nev { get; }
        public int uresTomeg { get; } //kg

        public int aktualisTeljesitmeny { get; } //MW

        UrhajoKategoria kategoria;
        IKomponens[] komponensek;

        public Urhajo(string nev, int uresTomeg, int aktualisTeljesitmeny, UrhajoKategoria kategoria, IKomponens komponensek)
        {
            this.nev = nev;
            this.uresTomeg = uresTomeg;
            this.aktualisTeljesitmeny = aktualisTeljesitmeny;
            this.kategoria = kategoria;
            if (kategoria==UrhajoKategoria.Yacht)
            {
                this.komponensek = new IKomponens[2];
            }
            else if (kategoria == UrhajoKategoria.Korvett)
            {
                this.komponensek = new IKomponens[4];
            }
            else if (kategoria == UrhajoKategoria.Fregatt)
            {
                this.komponensek = new IKomponens[6];
            }
            else if (kategoria == UrhajoKategoria.Rombolo)
            {
                this.komponensek = new IKomponens[8];
            }
            else if (kategoria == UrhajoKategoria.Teher)
            {
                this.komponensek = new IKomponens[8];
            }
            else if (kategoria == UrhajoKategoria.Allomas)
            {
                this.komponensek = new IKomponens[20];
            }
        }
        public void KomponensFelszerel(IKomponens komponens)
        {
            int idx = 0;
            komponensek[idx++] = komponens;
        }
        public void KomponensLeszerel(int index)
        {
            komponensek[index] = null;
        }
    }
}
