using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pisti
{
    public class Deste
    {
        //[]: Dizi operatörü. Belirlenmiş veri tipindeki birden fazla değerin taşınmasını sağlayan yapılardır.
        //Her bir değer için bir adres oluşturur. Bu adres 0'dan başlar. Ya dizi boyut verilerek boş olarak tanımlanır yada değerler direk gönderilerek.
        //public Kart[] Kartlar;

        //List<>: Belirlenmiş veri tipinde boyutu değiştirilebilir (ekleme/silme) bir yapıdır. Önceden bir boyut belirtilmez. Generic (Genel kullanım) amaçlıdır.
        //'<' ve '>' işaretleri arasına veri tipi yazılır.
        public List<Kart> KartListesi;
        private static Random random = new Random();

        public Deste()
        {
            //Değerler direk gönderilerek tanımlandı.
            string[] simgeler = { "Sinek", "Maça", "Kupa", "Karo" };
            string[] degerler = { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Vale", "Kız", "Papaz" };

            //Dizi boş olarak tanımlandı. Kaç elemanlı olduğu söylendi.
            //Kartlar = new Kart[52];
            //int kart_index = 0;

            //Liste<> boş olarak tanımlandı.
            KartListesi = new List<Kart>();

            for (int i = 0; i < simgeler.Length; i++)
            {
                for (int j = 0; j < degerler.Length; j++)
                {
                    Kart kart = new Kart(simgeler[i], degerler[j]);
                    //Console.WriteLine(kart.Show());
                    //Kartlar[kart_index] = kart;
                    //kart_index++;

                    //Bir List yapısına ekleme işlemi Add() metodu ile yapılır.
                    KartListesi.Add(kart);
                }
            }
            Karistir();
        }

        public void Karistir()
        {
            for (int i = 0; i < 100; i++)
            {
                int ilk_adres = random.Next(26);// 0 ~ 25 arası bir değer verir.
                int ikinci_adres = random.Next(26, 52);// 26 ~ 51 arası bir değer verir.

                //Standart değişken değiştirme.
                Kart bos = KartListesi[ilk_adres];
                KartListesi[ilk_adres] = KartListesi[ikinci_adres];
                KartListesi[ikinci_adres] = bos;
            }
        }

        //Kart ver:
        public List<Kart> KartVer(int kart_sayisi)
        {
            List<Kart> verilecek = new List<Kart>();
            for (int i = 0; i < kart_sayisi; i++)
            {
                Kart k = KartListesi[0];
                KartListesi.RemoveAt(0);
                verilecek.Add(k);
            }
            return verilecek;
        }

        public string Show()
        {
            string desteStr = "";
            /*
            for (int i = 0; i < Kartlar.Length; i++)
            {
                // \n: Yeni satır ekler.
                desteStr += Kartlar[i].Show() + "\n";
            }*/

            //List yapısının boyutu yoktur, eleman sayısı vardır. Count property'si ile sayılır.
            for (int i = 0; i < KartListesi.Count; i++)
            {
                //List yapısı adresleme de kullanır.
                // \n: Yeni satır ekler.
                desteStr += KartListesi[i].Show() + ", ";
            }
            return desteStr;
        }
    }
}
