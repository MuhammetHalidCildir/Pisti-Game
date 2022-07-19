using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisti
{
    public class Masa
    {
        public Deste Oyundestesi;
        public Oyuncu[] Oyuncular;
        public List<Kart> Yer;

        public Masa(int oyuncuSayisi)
        {
            Oyundestesi = new Deste();
            Yer = new List<Kart>();
            Oyuncular = new Oyuncu[oyuncuSayisi];
            for (int i = 0; i < oyuncuSayisi; i++)
            {
                Oyuncular[i] = new Oyuncu("Oyuncu " + (i + 1));
            }

            //Yere 4 kart açılır.
            Yer = Oyundestesi.KartVer(4);
        }

        public void Dagit()
        {
            for (int i = 0; i < Oyuncular.Length; i++)
            {
                Oyuncular[i].ElListe = Oyundestesi.KartVer(4);
            }
        }

        //Botların otomatik oynaması:
        public void Oyna()
        {
            //Destede kart bitene kadar oyuncular kart atmaya ve desteden kart dağıtılmaya devam eder.
            while (Oyundestesi.KartListesi.Count > 0)
            {
                //İlk dağıtımdan sonra oyuncularda kartlar bitince yeni kartlar dağıtılır.
                Dagit();
                //Oyuncularda kart kalmayana kadar oyuncular ellerindeki kartları sırasıyla atar.
                while (Oyuncular[0].ElListe.Count > 0)
                {
                    //Her el bütün oyuncular birer kart atar.
                    for (int i = 0; i < Oyuncular.Length; i++)
                    {
                        //Her oyuncu sırası geldiği zaman bir kart atar.
                        Kart atilan = Oyuncular[i].At();

                        //Oyun kuralları sağlanırsa oyuncu kartları toplar.
                        if (KuralKontrol(atilan))
                        {
                            Yer.Add(atilan);
                            Oyuncular[i].Topla(Yer);
                            Yer.Clear();
                        }
                        else
                        {
                            Yer.Add(atilan);
                        }
                    }
                }

            }
            //Tüm oyuncuların puanları toplanır. (Piştiler hariç o kısım sınıf içerisinde pratik ve ödev. Haftaya salı bakılacak)
            SkorHesapla();
        }

        public bool KuralKontrol(Kart atilan)
        {
            //Toplamak için yerde en az bir kart olmalı.
            if (Yer.Count > 0)
            {
                Kart yerdeki_en_ust_kart = Yer[Yer.Count - 1];
                //Vale atan alır
                if (atilan.ValeMi())
                {
                    return true;
                }
                //Yerdeki kart ile aynı değere sahip olan kartı atan alır.
                else if (yerdeki_en_ust_kart.AyniMi(atilan))
                {
                    return true;
                }
            }
            return false;
        }

        public void SkorHesapla()
        {
            for (int i = 0; i < Oyuncular.Length; i++)
            {
                Oyuncular[i].PuanHesapla();
            }
        }

        public string Show()
        {
            string masaStr = "";

            masaStr += "Deste: " + Oyundestesi.Show();

            masaStr += "\n\nYer: ";
            for (int i = 0; i < Yer.Count; i++)
            {
                //List yapısı adresleme de kullanır.
                // \n: Yeni satır ekler.
                masaStr += Yer[i].Show() + ", ";
            }
            masaStr += "\n\nOyuncular:\n";
            for (int i = 0; i < Oyuncular.Length; i++)
            {
                masaStr += Oyuncular[i].Show() + "\n\n";
            }

            return masaStr;
        }
    }
}
