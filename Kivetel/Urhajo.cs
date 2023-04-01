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
            
            if (nev==null)
            {
                throw new ArgumentNullException($"Hiba!\nA név (ami most '{nev}') nem lehet egyenlő a null értékkel!");
            }
            else
            {
                this.nev = nev;
            }

            if (0>=uresTomeg)
            {
                throw new ArgumentOutOfRangeException($"Hiba!\nAz űrhajó aktuális tömege (ami most {uresTomeg} kg) nem lehet kisebb vagy egyenlő nullával!");
            }
            else
            {
                this.uresTomeg = uresTomeg;
            }
            
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
            if (idx+1== komponensek.Length)
            {
                throw new KomponensNemFerElKivetel("nincs üres hely, de szerintem nem ez kell ide",komponens);
            }
        }
        public void KomponensLeszerel(int index)
        {
           
            if (komponensek[index]==null)
            {
                throw new KomponensNemTalalhatoKivetel("Nem található");
            }
            komponensek[index] = null;
        }

        public void Padlogaz()
        {
            for (int i = 0; i < komponensek.Length; i++)
            {
                if (komponensek[i].Allapot==false)
                {
                    komponensek[i].Aktival();
                    int teljesitménySzámitás=aktualisTeljesitmeny-komponensek[i].Teljesitmeny;
                    if (0>teljesitménySzámitás)
                    {
                        komponensek[i].Deaktival();
                        throw new NincsElegEnergiaKivetel(teljesitménySzámitás);
                        
                        for (int j = 0; j < komponensek.Length; j++)
                        {
                            komponensek[j].Deaktival();

                        }
                    }
                }
            }
            
        }

        public void Beindit()
        {
            
            for (int i = 0; i < komponensek.Length; i++)
            {
                if (komponensek[i] is Reaktor)
                {
                    komponensek[i].Aktival();
                }
                int szam = 0;
                szam += komponensek[i].Teljesitmeny;
                szam += aktualisTeljesitmeny;
            }
        }
    }
}
