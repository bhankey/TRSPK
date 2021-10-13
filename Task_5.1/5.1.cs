using System;
namespace S
{
	class Program
	{
		static void Main(string[] args)
		{
			double x = 77.66;
			int y = 45;
			Console.WriteLine("Денежный формат (С) :  {0:C3} ", x);
			Console.WriteLine("ЦелочисленныйЮ указывается минимальное кол-во цифр (D) :  {0:D4} ", y);
			Console.WriteLine("Формат експоненты (Е) :  {0:E} ", x);
			Console.WriteLine("Формат дробных чисел с фикс. точкой, указывается кол-во знаков после запятой (F) :  {0:F1} ", x);
			Console.WriteLine("Также задаёт формат дробных чисел с фикс. точкой:  {0:N3} ", x);
			Console.WriteLine("Формат процента:  {0:P1}", x);
			Console.WriteLine("Шестнадцатиричный формат :  {0:X}", y);
			long number = 72281337481;
			double digit = 1234.567891012345;
			string res = string.Format("{0:+# (###) ###-##-##}", number);
			Console.WriteLine("Число формата (+# (###) ##-##-##): {0}", res);
			Console.Write("Формат с символом точка: ");
			Console.WriteLine("{0:###.000}", digit);
			Console.Write("формат с символами E+0: ");
			Console.WriteLine("{0:000E+000}", digit);
		}
	}
}