using System;
using System.Collections;
using System.Threading.Channels;

namespace KullanicidanVeriAlma
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isProdMode = true;
            // Dizi Tanımlamalarıı:
            int[] sayilar; // Kullanıcıdan Alacağım Değerleri Tutacağım Dizi.
            // Değişken Tanımlaması:
            string input = string.Empty;
            char ayrac = ',';
            string formatlisayi = string.Empty;


            Console.Write("\n-> Kaç Eleman Tanımlayacaksınız: ");
            input = Console.ReadLine();

            int inputItemCount = -1;
            bool parseIsSuccess = int.TryParse(input, out inputItemCount);
            if (!parseIsSuccess)
            {
                Console.WriteLine("Hatalı Giriş Yaptınız");
                return;
            }

            if (inputItemCount == 0)
            {
                Console.WriteLine("0 girdiniz uygulama sonlanacaktır.");
                return;
            }


            sayilar = new int[inputItemCount];
            string[] formatliSayilar = new string[inputItemCount];


            if (!isProdMode)
            {
                Console.WriteLine("\n-> Dizi Başarılı Bir Şekilde Oluşturuldu.\n");
            }

            for (int i = 0; i < sayilar.Length; i++)
            {
                string? diziyeEklenecekVeri = string.Empty;
                int diziElemani = -1;
                Console.Write($"{i + 1}. Sayiyi giriniz : ");
                diziyeEklenecekVeri = Console.ReadLine();

                bool parseIsSucceses = int.TryParse(diziyeEklenecekVeri, out diziElemani);
                if (!parseIsSucceses)
                {
                    Console.WriteLine("Dizide numeric olmayan eleman mevcut");
                    return;
                }

                formatliSayilar[i] = Sayiformatla(diziElemani);
                sayilar[i] = diziElemani;
            }


            for (int i = 0; i < formatliSayilar.Length; i++)
            {
                formatlisayi += formatliSayilar[i] + ",";
            }
            
            double ortalama = OrtalamaHesapla(sayilar);
            string duzenlenmisSayi = SonKarakteriSil(formatlisayi);
            //
            // int ortalamam = (int)ortalama;
            // Console.WriteLine($"{SonKelimeyiBul(ortalamam)}");
            string sonKarakter = ortalama.ToString()[ortalama.ToString().Length-1].ToString();
            
            int LastResult = -1;
            bool SonSonuc = int.TryParse(sonKarakter, out LastResult);
            if (!SonSonuc)
            {
                Console.WriteLine("Çeviremedim Abi");
                return;
            }
            Console.WriteLine($"{duzenlenmisSayi} {ortalama}'{SonKelimeyiBul(LastResult)}");
            
        }

        public static double OrtalamaHesapla(int[] sayilar)
        {
            int toplam = 0;
            for (int i = 0; i < sayilar.Length; i++)
            {
                toplam += sayilar[i];
            }

            double ortalama = (double)toplam / sayilar.Length;

            return ortalama;
        }

        public static string Sayiformatla(int sayi)
        {
            return sayi.ToString().Length == 1
                ? "0" + sayi.ToString()
                : sayi.ToString();
        }

        public static string SonKarakteriSil(string input)
        {
            string result = string.Empty;
            for (int i = 0; i < input.Length - 1; i++)
            {
                result += input[i];
            }

            return result;
        }

        public static string SonKelimeyiBul(int sayi)
        {
            string[] ek = { "dır", "dir", "dir", "tür", "tür", "tir", "dır", "dir", "dir", "dur" };
            
            return ek[sayi];
        }
    }
}