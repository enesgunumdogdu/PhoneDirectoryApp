using PhoneDirectory;
using System;
using System.Collections;

namespace PhoneDirectory
{
    class Program
    {
        static List<Kisi> rehber = new List<Kisi>();
        static void Main(string[] args)
        {
            int x = 2;
            rehber.Add(new Kisi { Isim = "Enes", Soyisim = "Günümdoğdu", TelefonNumarasi = "05327851721" });
            rehber.Add(new Kisi { Isim = "Emir", Soyisim = "Başaran", TelefonNumarasi = "05428213506" });
            rehber.Add(new Kisi { Isim = "Fatih", Soyisim = "Taner", TelefonNumarasi = "05435940556" });
            rehber.Add(new Kisi { Isim = "Onur", Soyisim = "Elibüyük", TelefonNumarasi = "05253035489" });
            rehber.Add(new Kisi { Isim = "Eren", Soyisim = "Koçak", TelefonNumarasi = "05686752234" });
            while (x == 2)
            {
                Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz: ");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("(0) Çıkış Yapmak");
                string input = Console.ReadLine();
                int cevap;

                if (int.TryParse(input, out cevap))
                {
                    switch (cevap)
                    {
                        case 1:
                            kisiKaydet();
                            break;
                        case 2:
                            kisiSil();
                            break;
                        case 3:
                            kisiGuncelle();
                            break;
                        case 4:
                            rehberListele();
                            break;
                        case 5:
                            AramaYap();
                            break;
                        case 0:
                            x = 3;
                            break;
                        default:
                            Console.WriteLine("Hatalı tuşlama yaptınız. Lütfen menüde belirtilen sayılardan birini giriniz.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yaptınız. Lütfen sadece sayı giriniz.");
                }
            }
        }

        static void kisiKaydet()
        {
            Console.Write("Lütfen isim giriniz: ");
            string isim = Console.ReadLine();
            Console.Write("Lütfen soy isim giriniz: ");
            string soyisim = Console.ReadLine();
            Console.Write("Lütfen telefon numarası giriniz: ");
            string telefonNumarasi = Console.ReadLine();

            Kisi yeniKisi = new Kisi { Isim = isim, Soyisim = soyisim, TelefonNumarasi = telefonNumarasi };
            rehber.Add(yeniKisi);
            Console.WriteLine("Yeni kullanıcı başarıyla eklendi.");
        }

        static void kisiSil()
        {
            Console.WriteLine("\nLütfen silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string silinecekIsimSoyisim = Console.ReadLine();
            bool kisiBulundu = false;
            for (int i = 0; i < rehber.Count; i++)
            {
                if (rehber[i].Isim.Equals(silinecekIsimSoyisim, StringComparison.OrdinalIgnoreCase) ||
                    rehber[i].Soyisim.Equals(silinecekIsimSoyisim, StringComparison.OrdinalIgnoreCase))
                {
                    rehber.RemoveAt(i);
                    Console.WriteLine("Kişi başarıyla silindi.");
                    kisiBulundu = true;
                    break;
                }
            }
            if (!kisiBulundu)
            {
                Console.WriteLine("Belirtilen isim ya da soyisimle eşleşen kişi bulunamadı.");
            }
        }

        static void kisiGuncelle()
        {
            Console.WriteLine("\nLütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string guncellenecekIsimSoyisim = Console.ReadLine();
            bool kisiBulundu = false;
            for (int i = 0; i < rehber.Count; i++)
            {
                if (rehber[i].Isim.Equals(guncellenecekIsimSoyisim, StringComparison.OrdinalIgnoreCase) ||
                    rehber[i].Soyisim.Equals(guncellenecekIsimSoyisim, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Lütfen yeni telefon numarasını giriniz: ");
                    string yeniTelefonNumarasi = Console.ReadLine();
                    rehber[i].TelefonNumarasi = yeniTelefonNumarasi;
                    Console.WriteLine("Kişinin telefon numarası başarıyla güncellendi.");
                    kisiBulundu = true;
                    break;
                }
            }
            if (!kisiBulundu)
            {
                Console.WriteLine("Belirtilen isim ya da soyisimle eşleşen kişi bulunamadı.");
            }
        }

        static void rehberListele()
        {
            Console.WriteLine("\nTüm rehber aşağıdaki gibidir:\n");
            foreach (var kisi in rehber)
            {
                Console.WriteLine(kisi.Isim + " " + kisi.Soyisim + " " + kisi.TelefonNumarasi);
            }
        }

        static void AramaYap()
        {
            Console.WriteLine("\nLütfen arama yapmak istediğiniz tipi seçiniz: ");
            Console.WriteLine("İsim veya soyisme göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            string aramaTipi = Console.ReadLine();

            switch (aramaTipi)
            {
                case "1":
                    Console.WriteLine("Lütfen isim ya da soyisim giriniz: ");
                    string isimSoyisimArama = Console.ReadLine();
                    bool kisiBulundu = false;

                    foreach (var kisi in rehber)
                    {
                        if (kisi.Isim.Equals(isimSoyisimArama, StringComparison.OrdinalIgnoreCase) ||
                            kisi.Soyisim.Equals(isimSoyisimArama, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(kisi.Isim + " " + kisi.Soyisim + " " + kisi.TelefonNumarasi);
                            kisiBulundu = true;
                        }
                    }

                    if (!kisiBulundu)
                    {
                        Console.WriteLine("Belirtilen isim ya da soyisimle eşleşen kişi bulunamadı.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Lütfen telefon numarası giriniz: ");
                    string telefonNumarasiArama = Console.ReadLine();
                    kisiBulundu = false;

                    foreach (var kisi in rehber)
                    {
                        if (kisi.TelefonNumarasi.Equals(telefonNumarasiArama))
                        {
                            Console.WriteLine(kisi.Isim + " " + kisi.Soyisim + " " + kisi.TelefonNumarasi);
                            kisiBulundu = true;
                        }
                    }

                    if (!kisiBulundu)
                    {
                        Console.WriteLine("Belirtilen telefon numarasıyla eşleşen kişi bulunamadı.");
                    }
                    break;

                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen 1 ya da 2 girin.");
                    break;
            }
        }
    }

}