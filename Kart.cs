using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisti
{
    public class Kart
    {
        private string simge;
        private string deger;
        private int puan;

        //Constructor: Yapıcı metot, sınıfın new operatörüyle çağırıldığı an çalışan kodları tutar.
        public Kart(string s, string d)
        {
            simge = s;
            deger = d;

            if (deger == "As" || deger == "Vale")
            {
                puan = 1;
            }
            else if (deger == "2" && simge == "Sinek")
            {
                puan = 2;
            }
            else if (deger == "10" && simge == "Karo")
            {
                puan = 3;
            }
            else
            {
                puan = 0;
            }
        }

        //Kart vale ise yerdekileri toplar.
        public bool ValeMi()
        {
            return deger == "Vale";
        }

        //Verilen kart ile bu kart aynı değere mi sahip?
        public bool AyniMi(Kart kart)
        {
            return deger == kart.DegerGoster();
        }

        //Private property yapılarını sadece okumak için Goster metotları (get) yazıldı.
        public string DegerGoster()
        {
            return deger;
        }

        public int PuanGoster()
        {
            return puan;
        }

        public string SimgeGoster()
        {
            return simge;
        }

        public string Show()
        {
            return string.Format("{0} {1} ({2})", simge, deger, puan);
        }
    }
}
