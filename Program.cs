using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Kart k1 = new Kart("Kupa", "10");
            Console.WriteLine(k1.Show());

            Kart k2 = new Kart("Sinek", "2");
            Console.WriteLine(k2.Show());
            */
            /*
            Deste deste = new Deste();
            Console.WriteLine(deste.Show());
            */

            Masa masa = new Masa(4);
            //masa.Dagit();//ilk el dağıtıldı.
            masa.Oyna();
            Console.WriteLine(masa.Show());
        }
    }
}
