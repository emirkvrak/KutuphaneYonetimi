

namespace Kutuphane;

class Program
{

    
    static void Main()
    {

        List<Kitap> kitapListesi = new List<Kitap>
        {
            new() { Id = 1, Ad = "Nutuk", Yazar = "Mustafa Kemal Atatürk", Fiyat= 150, OduncteMi = false},
            new() { Id = 2, Ad = "Suç ve Ceza", Yazar = "Dostoyevski", Fiyat= 100, OduncteMi = false}
        };

        int id = 2;

        while (true)
        {
            Console.Write("\nLütfen bir seçenek secin :\n" +
                          "1.Kitap ekle \n" +
                          "2.Kitapları listele \n" +
                          "3.Ada göre ara \n" +
                          "4.Çıkış\n" +
                          "Seçiminiz:");

            string? input = Console.ReadLine();

            int? secim;

            if (int.TryParse(input, out int result))
            {
                secim = result;
            }
            else
            {
                Console.WriteLine("\nGeçerli bir rakam girin (1,2,3,4)\n");
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
                    Console.WriteLine("\n4.Çıkış seçtiniz\n");
                    return;
                default:
                    Console.WriteLine("\nGeçerli bir rakam girin (1,2,3,4)\n");
                    break;

            }
        }
    }

    public static void KitapEkle(int id ,List<Kitap> kitaplar)
    {

        
        Console.WriteLine("\nLütfen sırasıyla eklemek istediğiniz kitabın bilgilerini girin:\n");

        Console.Write("\nAd:");
        string? ad = Console.ReadLine();

        Console.Write("\nYazar:");
        string? yazar = Console.ReadLine();

        int fiyat = 0;
        while (true) 
        {
            Console.Write("\nFiyat:");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out fiyat)) 
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

            if (input2 == "E")
            { 
                oduncteMi = true;
                break;
            }
            else if (input2 == "H")
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
            Console.WriteLine($"Id: {k.Id},\nAd: {k.Ad},\nYazar: {k.Yazar},\nFiyat: {k.Fiyat},\nÖdünçte mi: {(k.OduncteMi ? "evet" : "hayır")}\n");
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
                Console.WriteLine($"Id: {k.Id},\nAd: {k.Ad},\nYazar: {k.Yazar},\nFiyat: {k.Fiyat},\nÖdünçte mi: {(k.OduncteMi ? "evet" : "hayır")}\n");
                bulunduMu = true;
            }

        }

        if (bulunduMu == false) 
        {
            Console.WriteLine("Böyle bir ad bulunamadı");
        }
        

    }


}
