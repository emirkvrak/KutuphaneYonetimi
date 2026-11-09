
namespace Kutuphane;

class Program 
{
    static void Main() 
    {

        while (true) {

            Console.Write("Lütfen bir seçenek secin :\n" +
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
            

            switch(secim)
            {

                case 1:
                    Console.WriteLine("\n1.Kitap ekle seçtiniz\n");
                    break;
                case 2:
                    Console.WriteLine("\n2.Kitapları listele seçtiniz\n");
                    break;
                case 3:
                    Console.WriteLine("\n3.Ada göre ara seçtiniz\n");
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

  
}
