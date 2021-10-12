using System;
using System.Diagnostics; // для stopwatch

class Program
{
    private static string ReadData()
    // возвращает тестовый набор данных
    {
      return "abcdefghijklmnopqrstuvyxz0123456789abcdefghijklmnopqrstuvyxz0123456789abcdefghijklmnopqrstuvyxz0123456789" + 1;
    }
    
    private static TimeSpan TimeOfMultiComparison(ref string strA, ref string strB, int N)
    // возвращает время N сравнений строк, заданных ссылками 
    {
      var stopwatch = Stopwatch.StartNew();
      int nComparison = 0;

      for (int i=0; i<N; i++) 
        { 
          if (strA==strB) nComparison++;
        }
    
      stopwatch.Stop();

      return stopwatch.Elapsed;
    }

    public static void Main()
    {
      var a = string.Intern(ReadData());
      var b = string.Intern(ReadData());
      // переменные a и b интернализированы

      var c = ReadData();
      var d = ReadData();
      // переменные c и d не интернализированы

      Console.WriteLine("Время сравнения с интернализацией: {0}",
                        TimeOfMultiComparison(ref a, ref b, 250*1000*1000));
      Console.WriteLine("Время сравнения без интернализации: {0}",
                        TimeOfMultiComparison(ref c, ref d, 250*1000*1000));
    }

}
// https://coderoad.ru/8054471/#42564901 - прототип
// https://coderoad.ru/8054471/#44751986 - объяснение