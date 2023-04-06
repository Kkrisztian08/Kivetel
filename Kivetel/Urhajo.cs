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

        public Urhajo(string nev, int uresTomeg, int aktualisTeljesitmeny, UrhajoKategoria kategoria)
        {
            
            if (nev==null)
            {
                throw new ArgumentNullException($"[KIVETEL] Value cannot be null.\nParameter name: nev");
            }
            else
            {
                this.nev = nev;
            }

            if (0>=uresTomeg)
            {
                throw new ArgumentOutOfRangeException($"[KIVETEL] Az üres tömeg nem lehet negatív!\nParameter name: uresTomeg");
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
            Console.WriteLine($"{this.nev} létrehozva!");
        }
        public void KomponensFelszerel(IKomponens komponens)
        {
            int idx = 0;
            bool vanHely=true;
            
            while (komponensek.Length>idx && vanHely)
            {
                if (komponensek[idx]==null)
                {
                    komponensek[idx] = komponens;
                    vanHely = false;
                    Console.WriteLine($"[Hozzaadas] Hajtomu hozzaadva a(z) {this.nev} hajohoz");
                }
                idx++;
                
            }
            
            if (vanHely)
            {
                throw new KomponensNemFerElKivetel("[KIVETEL] A komponens nem fér el!", komponens);
            }
            
        }
        public void KomponensLeszerel(int index)
        {
           
            if (index>komponensek.Length)
            {
                throw new KomponensNemTalalhatoKivetel("[KIVETEL] A törölni kívánt komponens nem található!");
            }
            else if(komponensek[index] == null )
            {
                throw new KomponensNemTalalhatoKivetel("[KIVETEL] A törölni kívánt komponens nem található!");
            }
            komponensek[index] = null;
            Console.WriteLine($"[Leszereles] A(z) {index} indexu komponens leszerelve a(z) {this.nev} hajorol");
        }

        public void Beindit()
        {
            for (int i = 0; i < komponensek.Length; i++)
            {
                try
                {
                    if (komponensek[i] is Reaktor)
                    {
                        Console.WriteLine($"[Beinditas] A(z) {this.nev} urhajo beinditva");
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
        public void Padlogaz()
        {
            bool hamis=false;
            int teljesitménySzámitás;
            for (int i = 0; i < komponensek.Length; i++)
            {
                if (komponensek[i] is Hajtomu)
                {
                    if (komponensek[i].Allapot == hamis)
                    {
                        komponensek[i].Aktival();
                        teljesitménySzámitás = aktualisTeljesitmeny - komponensek[i].Teljesitmeny;
                        if (0 > teljesitménySzámitás)
                        {
                            komponensek[i].Deaktival();
                            for (int j = 0; j < komponensek.Length; j++)
                            {
                                komponensek[i].Deaktival();
                                aktualisTeljesitmeny = aktualisTeljesitmeny + komponensek[i].Teljesitmeny;
                            }
                        }
                        throw new NincsElegEnergiaKivetel(teljesitménySzámitás);
                    }
                }

            }
            Console.WriteLine($"[Padlogaz] A(z) {this.nev} urhajo padlogazon megy");
            
        }
        public void Leallit()
        {
            try
            {
                for (int i = 0; i < komponensek.Length; i++)
                {
                    komponensek[i]?.Deaktival();
                }
                Console.WriteLine($"[Leallitas] A(z) {this.nev} urhajo leallitasa meghivva");
            }
            catch (Exception Exception)
            {
                throw new NemDeaktivalhatoKivetel("[KIVETEL] Egy komponens nem deaktiválható!", Exception);
            }
        }
    }
}
