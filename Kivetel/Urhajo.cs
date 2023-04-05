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
        public int aktualisTeljesitmeny { get; private set; } //MW

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
            bool vanHely=true;
            komponensek[idx++] = komponens;
            while (komponensek.Length>idx && vanHely)
            {
                if (komponensek[idx]==null)
                {
                    vanHely = false;
                    komponensek[idx] = komponens;
                }
                idx++;
            }
            if (vanHely)
            {
                throw new KomponensNemFerElKivetel("",komponens);
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
                if (komponensek[i] is Hajtomu)
                {
                    if (komponensek[i].Allapot == false)
                    {
                        komponensek[i].Aktival();
                        int teljesitménySzámitás = aktualisTeljesitmeny - komponensek[i].Teljesitmeny;
                        if (0 > teljesitménySzámitás)
                        {
                            komponensek[i].Deaktival();
                            for (int j = 0; j < komponensek.Length; j++)
                            {
                                komponensek[i].Deaktival();
                                aktualisTeljesitmeny += komponensek[i].Teljesitmeny;
                            }
                        }
                        throw new NincsElegEnergiaKivetel(teljesitménySzámitás);
                    }
                }
                
            }
            Console.WriteLine($"");
            
        }

        public void Beindit()
        {
            Console.WriteLine($"");
            for (int i = 0; i < komponensek.Length; i++)
            {
                try
                {
                    if (komponensek[i] is Reaktor)
                    {
                        komponensek[i].Aktival();
                        aktualisTeljesitmeny += komponensek[i].Teljesitmeny;
                    }
                }
                catch (InvalidOperationException IOE)
                {
                    Console.WriteLine(IOE.Message);
                }catch(NotSupportedException ) 
                {
                    KomponensLeszerel(i);
                } 
            }
        }

        public void Leallit()
        {
            Console.WriteLine($"");
            try
            {
                for (int i = 0; i < komponensek.Length; i++)
                {
                    komponensek[i].Deaktival();
                }
            }
            catch (Exception Exception)
            {
                throw new NemDeaktivalhatoKivetel("", Exception);
            }
        }
    }
}
