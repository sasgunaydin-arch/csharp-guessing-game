using System;

class GuessingGame
{
    static void Main()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("  SAYIYI TAHMİN ET OYUNUNA HOŞ GELDİNİZ!");
        Console.WriteLine("==================================================");
        
        bool playAgain = true;
        
        while (playAgain)
        {
            PlayGame();
            
            Console.WriteLine("\nTekrar oynamak ister misin? (E/H): ");
            string response = Console.ReadLine()?.ToUpper() ?? "H";
            playAgain = response == "E";
            Console.WriteLine();
        }
        
        Console.WriteLine("👋 Oyunu oynadığın için teşekkürler! Hoşça kalın!");
    }
    
    static void PlayGame()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int attempts = 0;
        bool guessed = false;
        
        Console.WriteLine("\nBilgisayar 1 ile 100 arasında bir sayı seçti.");
        Console.WriteLine("Sen de o sayıyı tahmin etmeye çalış!\n");
        
        while (!guessed)
        {
            try
            {
                Console.Write("Tahmininizi girin (1-100): ");
                string input = Console.ReadLine();
                
                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("❌ Geçersiz giriş! Lütfen bir sayı girin.\n");
                    continue;
                }
                
                if (guess < 1 || guess > 100)
                {
                    Console.WriteLine("❌ Lütfen 1 ile 100 arasında bir sayı girin!\n");
                    continue;
                }
                
                attempts++;
                
                if (guess < secretNumber)
                {
                    Console.WriteLine("📈 Daha yüksek bir sayı tahmin et!\n");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("📉 Daha düşük bir sayı tahmin et!\n");
                }
                else
                {
                    guessed = true;
                    Console.WriteLine("\n==================================================");
                    Console.WriteLine("🎉 TEBRIKLER! DOĞRU BULDIN!");
                    Console.WriteLine($"✅ Gizli sayı: {secretNumber}");
                    Console.WriteLine($"📊 Toplam deneme: {attempts}");
                    Console.WriteLine("==================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Hata: {ex.Message}\n");
            }
        }
    }
}
