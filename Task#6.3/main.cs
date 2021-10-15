using System;
 
public enum WeekDays { пн, вт, ср, чт, пт, сб, вс }

class Program
  {
        static void Main(string[] args)
        {
            Console.Write("Введите день недели [0..6]: ");
            int w_id = Convert.ToInt32(Console.ReadLine());
              
            WeekDays w = (WeekDays)w_id;

            Console.WriteLine($"День недели: {w}");
 
            Console.ReadKey();
        }
  }