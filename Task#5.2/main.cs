using System;
using System.Globalization;

public class Program
{
   public static void Main()
   {
      DateTime localDate = DateTime.Now;

      String[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "de-DE", "ru-RU", "tk-TM" } ;

      String tempStringDate, tempStringValue;
      
      Decimal value = 9876543.21m;

      NumberStyles style; // переменная для parse
      
      foreach (var cultureName in cultureNames) {
          var culture = new CultureInfo(cultureName); // информация, создаваемая по имени культуры
          Console.WriteLine("{0}:", culture.NativeName);

          tempStringDate = localDate.ToString("F",culture); // F - длинный формат даты/времени для текущей культуры
          Console.WriteLine("\tLocal date and time: {0}", tempStringDate);
          
          tempStringValue = value.ToString("C",culture); // C - длинный формат валюты для текущей культуры
          Console.WriteLine("\tCurrency Value:  {0}", tempStringValue);

          Console.WriteLine("\tParsing date/time back to value: {0}",                       DateTime.Parse(tempStringDate, culture));
          
          style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol; // допуск числа и символа валюты

          Console.WriteLine("\tParsing currency amount back to value: {0}",                                     Decimal.Parse(tempStringValue, style, culture)); // parse с использованием стиля и культуры
          Console.WriteLine();
      }
   }
}
