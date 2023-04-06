using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    public enum UrhajoKategoria 
    {   Yacht, 
        Korvett, 
        Fregatt, 
        Rombolo, 
        Teher, 
        Allomas
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Urhajo u1 = new Urhajo("Star Destroyer #5530",1,200,UrhajoKategoria.Yacht);
                Urhajo u2 = new Urhajo("Serenity",1,200,UrhajoKategoria.Yacht);
                Urhajo u3 = new Urhajo("Old Bessie", 1,200,UrhajoKategoria.Yacht);
                Urhajo u4 = new Urhajo("Razorback", 1,200,UrhajoKategoria.Yacht);
                Hajtomu h1 = new Hajtomu(6);
                Hajtomu h2 = new Hajtomu(5);
                Hajtomu h3 = new Hajtomu(4);
                Hajtomu h4 = new Hajtomu(3);
                Reaktor r1 = new Reaktor(7);
                u1.KomponensFelszerel(r1);
                u1.KomponensFelszerel(h2);
                //u1.KomponensFelszerel(h2);
                //u1.KomponensFelszerel(h2);
                //u1.KomponensFelszerel(h2);
                u1.KomponensLeszerel(1);
                //u1.Beindit();
                //u1.Padlogaz();
                u1.Leallit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
