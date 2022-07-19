using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisti
{
    public class Oyuncu
    {
        public string Ad;
        public int Puan;
        //public Kart[] Toplanan;
        //public Kart[] El;
        public List<Kart> ToplananListe;
        public List<Kart> ElListe;
        private static Random random = new Random();

        public Oyuncu(string ad)
        {
            Ad = ad;
            Puan = 0;
            //Toplanan = new Kart[52];
            //El = new Kart[4];
            ToplananListe = new List<Kart>();
            ElListe = new List<Kart>();
        }

        public Kart At()
        {
            Kart atilacak = null;
            //Eğer canlı oyuncu sistemi varsa, kart talebi burada istenir.

            //Eğer bot sistemi varsa yapay zekadan talep burada istenir.
            int i = random.Next(ElListe.Count);
            atilacak = ElListe[i];
            //El[i] = null;
            //Belirtilen adresteki eleman kaldırılır.
            ElListe.RemoveAt(i);
            //veya
            //Belirtilen eleman kaldırılır.
            //ElListe.Remove(atilacak);

            return atilacak;
        }

        public void Topla(List<Kart> yer)
        {
            //AddRange: Bir koleksiyona aynı tipteki başka bir koleksiyonu eklemek için kullanırız.
            ToplananListe.AddRange(yer);
        }

        public void PuanHesapla()
        {
            for (int i = 0; i < ToplananListe.Count; i++)
            {
                Puan += ToplananListe[i].PuanGoster();
            }
        }
        public string Show()
        {
            string oyuncuStr = Ad + " (" + Puan + "):\n";
            oyuncuStr += "Toplanan Kartlar:";
            for (int i = 0; i < ToplananListe.Count; i++)
            {
                oyuncuStr += ToplananListe[i].Show() + ", ";
            }
            oyuncuStr += "\nEl: ";
            for (int i = 0; i < ElListe.Count; i++)
            {
                oyuncuStr += ElListe[i].Show() + ", ";
            }

            return oyuncuStr;
        }
    }
}