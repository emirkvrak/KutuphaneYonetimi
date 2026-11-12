

namespace Kutuphane;

class Program
{

    
    static void Main()
    {

        List<Kitap> kitapListesi = new List<Kitap>
        {
            new() { Id = 1, Ad = "Nutuk", Yazar = "Mustafa Kemal Atatürk", Fiyat= 150m, OduncteMi = false},
            new() { Id = 2, Ad = "Suç ve Ceza", Yazar = "Dostoyevski", Fiyat= 100m, OduncteMi = false}
        };

        int id = 2;

        while (true)
        {
            Console.Write("\nLütfen bir seçenek secin :\n" +
                          "1.Kitap ekle\n" +
                          "2.Kitapları listele\n" +
                          "3.Ada göre ara\n" +
                          "4.Ödünç durumu değiştir\n" +
                          "5.Çıkış\n" +
                          "Seçiminiz:");

            string? input = Console.ReadLine();

            int? secim;

            if (int.TryParse(input, out int result))
            {
                secim = result;
            }
            else
            {
                Console.WriteLine("\nGeçerli bir rakam girin (1,2,3,4,5)\n");
                continue;
            }


            switch (secim)
            {

                case 1:
                    Console.WriteLine("\n1.Kitap ekle seçtiniz\n");
                    KitapEkle(++id ,kitapListesi);
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
                    Console.WriteLine("\nGeçerli bir rakam girin (1,2,3,4,5)\n");
                    break;

            }
        }
    }

    public static void KitapEkle(int id ,List<Kitap> kitaplar)
    {

        
        Console.WriteLine("\nLütfen sırasıyla eklemek istediğiniz kitabın bilgilerini girin:\n");
        
        string? ad;
        do 
        {
            Console.Write("\nAd:");
            ad = Console.ReadLine();
        } 
        while (string.IsNullOrWhiteSpace(ad));
        ad = ad.Trim();


        string? yazar;
        do
        {
            Console.Write("\nYazar:");
            yazar = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(yazar));
        yazar = yazar.Trim();


        decimal fiyat = 0.0m;
        while (true) 
        {
            Console.Write("\nFiyat:");
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out fiyat) && fiyat >= 0)
            {
                break;
            }
            else 
            {
                Console.Write("\nİşleminiz geçersiz lütfen doğru değer girin\n");
            }
        }

        bool oduncteMi;
        while (true)
        {
            Console.Write("\nBirisine ödünç verildi mi? (E, H):");
            string? input2 = Console.ReadLine();

            if (string.Equals(input2, "E", StringComparison.OrdinalIgnoreCase))
            { 
                oduncteMi = true;
                break;
            }
            else if (string.Equals(input2, "H", StringComparison.OrdinalIgnoreCase))
            { 
                oduncteMi = false;
                break;
            }
            else
            {
                Console.Write("\nİşleminiz geçersiz lütfen doğru metin değer girin\n");
            }
        }
        

        Kitap kitap = new Kitap() { Id = id, Ad = ad, Yazar = yazar, Fiyat = fiyat, OduncteMi = oduncteMi };
        kitaplar.Add(kitap);
        Console.Write("\nKitap eklendi\n");
    }

    
    public static void KitaplariListele(List<Kitap> kitaplar) 
    {

        
        if (kitaplar.Count == 0)
        {
            Console.Write("\nListe boş\n");
            return;
        }

        foreach (Kitap k in kitaplar) 
        {
            
            KitapYazdir(k);
        }
    
    }


    public static void KitapArama(List<Kitap> kitaplar) {

        if (kitaplar.Count == 0)
        {
            Console.Write("\nListe boş\n");
            return;
        }


        Console.Write("\nAd:");
        string? ad = Console.ReadLine();


        bool bulunduMu = false;
        foreach(Kitap k in kitaplar)
        {

            if (string.Equals(k.Ad, ad, StringComparison.OrdinalIgnoreCase)) {
                
                KitapYazdir(k);
                bulunduMu = true;
            }

        }

        if (bulunduMu == false) 
        {
            Console.WriteLine("Böyle bir ad bulunamadı");
        }
        

    }


    public static void KitapOduncDegistir(List<Kitap> kitaplar) 
    {
        if (kitaplar.Count == 0)
        {
            Console.Write("\nListe boş\n");
            return;
        }

        int id;
        while (true)
        {
            Console.Write("\nId:");

            if (int.TryParse(Console.ReadLine(), out id))
            {
                break;
            }

            Console.WriteLine("Geçersiz Id, bir tam sayı girin.");
        }

        bool bulunan = false;
        foreach (var k in kitaplar) 
        {
            if (k.Id == id)
            {
                k.OduncteMi = !k.OduncteMi;
                Console.WriteLine($"\nTamamlandı ödünç durumu : {(k.OduncteMi ? "evet" : "hayır")}");
                bulunan = true;
                break;
            }

        }

        if(bulunan is false) 
        {
            Console.WriteLine("\n Kitap Bulunamadı");
            return;
        }

    }



    public static void KitapYazdir(Kitap k) {

        Console.WriteLine($"Id: {k.Id},\nAd: {k.Ad},\nYazar: {k.Yazar},\nFiyat: {k.Fiyat:N2},\nÖdünçte mi: {(k.OduncteMi ? "evet" : "hayır")}\n");
    }


}
