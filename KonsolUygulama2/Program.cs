using System;
using System.Text.RegularExpressions;

namespace MetinDuzeltmeUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Metin girin (Çıkmak için 'q' tuşuna basın):");
                string inputText = Console.ReadLine();

                if (inputText.ToLower() == "q")
                {
                    Console.WriteLine("Program sonlandırılıyor...");
                    break;
                }

                string formattedText = FormatText(inputText);

                Console.WriteLine("Düzenlenmiş Metin:");
                Console.WriteLine(formattedText);
            }
        }

        static string FormatText(string text)
        {
            // Metnin başındaki boşlukları temizle
            text = text.Trim();

            // Metnin ilk harfini büyük yap
            if (!string.IsNullOrEmpty(text))
            {
                text = char.ToUpper(text[0]) + text.Substring(1);
            }

            // Birden fazla boşluğu tek boşlukla değiştir
            text = Regex.Replace(text, @"\s+", " ");

            // Noktalama işaretinden önce boşluk bırakma
            text = Regex.Replace(text, @"\s+([.,!?])", "$1");

            // Noktalama işaretleri sonrasında boşluk kontrolü yap ve ekle
            text = Regex.Replace(text, @"(\w)([.,!?])", "$1$2 ");

            // Eğer noktalama işareti sonrasında boşluk yoksa ekle
            text = Regex.Replace(text, @"([.,!?])(\w)", "$1 $2");

            // Birden fazla ardışık noktalama işaretlerini tek bir işaretle değiştir
            text = Regex.Replace(text, @"[.,!?]+", "$0");

            // Büyük harfle başlayan cümlelerin ardından gelen küçük harfi büyük yap
            text = Regex.Replace(text, @"(?<=\.|\?|\!)\s*\w", m => m.Value.ToUpper());

            return text;
        }
    }
}
