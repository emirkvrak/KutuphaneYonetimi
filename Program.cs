﻿namespace Kutuphane;

class Program
{
    const string GecersizSecimMesaji = "\nGeçerli bir rakam girin (1,2,3,4,5)\n";

    static void Main()
    {
        List<Kitap> kitapListesi = new()
        {
            new() { Id = 1, Ad = "Nutuk", Yazar = "Mustafa Kemal Atatürk", Fiyat = 150m, OduncteMi = false },
            new() { Id = 2, Ad = "Suç ve Ceza", Yazar = "Dostoyevski", Fiyat = 100m, OduncteMi = false }
        };

        int id = 2;

        while (true)
        {
            Console.Write("\nLütfen bir seçenek seçin :\n" +
                          "1.Kitap ekle\n" +
                          "2.Kitapları listele\n" +
                          "3.Ada göre ara\n" +
                          "4.Ödünç durumu değiştir\n" +
                          "5.Çıkış\n" +
                          "Seçiminiz:");

            if (!int.TryParse(Console.ReadLine(), out int secim))
            {
                Console.WriteLine(GecersizSecimMesaji);
                continue;
            }

            switch (secim)
            {
                case 1:
                    Console.WriteLine("\n1.Kitap ekle seçtiniz\n");
                    KitapEkle(++id, kitapListesi);
                    break;
                case 2:
                    Console.WriteLine("\n2.Kitapları listele seçtiniz\n");
                    KitaplariListele(kitapListesi);
                    break;
                case 3:
                    Console.WriteLine("\n3.Ada göre ara seçtiniz\n");
                    KitapArama(kitapListesi);
                    break;
                case 4:
                    Console.WriteLine("\n4.Ödünç durumu değiştir seçtiniz\n");
                    KitapOduncDegistir(kitapListesi);
                    break;
                case 5:
                    Console.WriteLine("\n5.Çıkış seçtiniz\n");
                    return;
                default:
                    Console.WriteLine(GecersizSecimMesaji);
                    break;
            }
        }
    }

    public static void KitapEkle(int id, List<Kitap> kitaplar)
    {
        Console.WriteLine("\nLütfen sırasıyla eklemek istediğiniz kitabın bilgilerini girin:\n");

        string ad = BosOlmayanOku("Ad");
        string yazar = BosOlmayanOku("Yazar");
        decimal fiyat = FiyatOku();
        bool oduncteMi = EvetHayirOku("Birisine ödünç verildi mi? (E, H)");

        Kitap kitap = new() { Id = id, Ad = ad, Yazar = yazar, Fiyat = fiyat, OduncteMi = oduncteMi };
        kitaplar.Add(kitap);
        Console.WriteLine("\nKitap eklendi\n");
    }

    public static void KitaplariListele(List<Kitap> kitaplar)
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("\nListe boş\n");
            return;
        }

        foreach (Kitap k in kitaplar)
        {
            KitapYazdir(k);
        }
    }

    public static void KitapArama(List<Kitap> kitaplar)
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("\nListe boş\n");
            return;
        }

        Console.Write("\nAd:");
        string? ad = Console.ReadLine()?.Trim();

        bool bulunduMu = false;
        foreach (Kitap k in kitaplar)
        {
            if (string.Equals(k.Ad, ad, StringComparison.OrdinalIgnoreCase))
            {
                KitapYazdir(k);
                bulunduMu = true;
            }
        }

        if (!bulunduMu)
        {
            Console.WriteLine("\nBöyle bir ad bulunamadı\n");
        }
    }

    public static void KitapOduncDegistir(List<Kitap> kitaplar)
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("\nListe boş\n");
            return;
        }

        int id = IdOku();

        foreach (Kitap k in kitaplar)
        {
            if (k.Id == id)
            {
                k.OduncteMi = !k.OduncteMi;
                Console.WriteLine($"\n{k.Ad} {(k.OduncteMi ? "ödünç verildi" : "iade alındı")}\n");
                return;
            }
        }

        Console.WriteLine("\nBöyle bir kitap yok\n");
    }

    public static void KitapYazdir(Kitap k)
    {
        Console.WriteLine($"Id: {k.Id},\nAd: {k.Ad},\nYazar: {k.Yazar},\nFiyat: {k.Fiyat:N2},\nÖdünçte mi: {(k.OduncteMi ? "evet" : "hayır")}\n");
    }

    // --- Giriş okuma yardımcıları: geçerli değer gelene kadar tekrar sorar ---

    static string BosOlmayanOku(string etiket)
    {
        while (true)
        {
            Console.Write($"\n{etiket}:");
            string? giris = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(giris))
            {
                return giris.Trim();
            }

            Console.WriteLine($"{etiket} boş olamaz.");
        }
    }

    static decimal FiyatOku()
    {
        while (true)
        {
            Console.Write("\nFiyat:");

            if (decimal.TryParse(Console.ReadLine(), out decimal fiyat) && fiyat >= 0)
            {
                return fiyat;
            }

            Console.WriteLine("Geçersiz fiyat. Sıfır ya da daha büyük bir sayı girin (örn: 49,90).");
        }
    }

    static bool EvetHayirOku(string soru)
    {
        while (true)
        {
            Console.Write($"\n{soru}:");
            string? giris = Console.ReadLine()?.Trim();

            if (string.Equals(giris, "E", StringComparison.OrdinalIgnoreCase)) return true;
            if (string.Equals(giris, "H", StringComparison.OrdinalIgnoreCase)) return false;

            Console.WriteLine("Geçersiz giriş, E ya da H yazın.");
        }
    }

    static int IdOku()
    {
        while (true)
        {
            Console.Write("\nId:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
            }

            Console.WriteLine("Geçersiz Id, bir tam sayı girin.");
        }
    }
}
