using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Task4_5
{
    class KeyBoardManager
    {
        public delegate void KeyPressdEvent(ConsoleKeyInfo key);

        public event KeyPressdEvent Key3 = delegate { };
        public event KeyPressdEvent Key5 =  delegate { };
        public event KeyPressdEvent Digit =  delegate { };
        public event KeyPressdEvent AnyKey =  delegate { };

        private static Dictionary<ConsoleKey, bool> DigitKey = new Dictionary<ConsoleKey, bool>()
        {
            {ConsoleKey.D0, true},
            {ConsoleKey.D1, true},
            {ConsoleKey.D2, true},
            {ConsoleKey.D3, true},
            {ConsoleKey.D4, true},
            {ConsoleKey.D5, true},
            {ConsoleKey.D6, true},
            {ConsoleKey.D7, true},
            {ConsoleKey.D8, true},
            {ConsoleKey.D9, true},
        };

        public void ListenKey()
        {
            do
            {
                while (!Console.KeyAvailable)
                {
                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.D3)
                    {
                        Key3(key);
                    }
                    else if (key.Key == ConsoleKey.D5)
                    {
                        Key5(key);
                    }

                    if (DigitKey.TryGetValue(key.Key, out bool _))
                    {
                        Digit(key);
                    }

                    AnyKey(key);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        
    }

    class ThreeSubscriber
    {
        public void Message(ConsoleKeyInfo _)
        {
            Console.WriteLine("Button 3 pressed");
        }
        
    }

    class FiveSubscriber
    {
        public void Message(ConsoleKeyInfo _)
        {
            Console.WriteLine("Button 5 pressed");
        }
    }

    class DigitSubscriber
    {
        public void Message(ConsoleKeyInfo key)
        {
            Console.WriteLine($"This digitButton pressed: {key.KeyChar}");
        }
    }
    
    class LogSubscriber
    {
        public void Message(ConsoleKeyInfo key)
        {
            Console.WriteLine($"This button was pressed: {key.KeyChar}");
            var streamWriter = File.AppendText("./keyLogger");
            streamWriter.WriteLine($"{key.KeyChar} was pressed");
            streamWriter.Close();
        }
    }
    
    class Program
    {
      //  public static ConcoleKeyInfo ReadKey(bool incept) 
        
        static void Main(string[] args)
        {
            var keyBoardManager = new KeyBoardManager();

            var threeSubscriber = new ThreeSubscriber();
            var fiveSubscriber = new FiveSubscriber();
            var digitSubscriber = new DigitSubscriber();
            var logSubscriber = new LogSubscriber();
            
            keyBoardManager.Key3 += threeSubscriber.Message;
            keyBoardManager.Key5 += fiveSubscriber.Message;
            keyBoardManager.Digit +=  digitSubscriber.Message;
            keyBoardManager.AnyKey += logSubscriber.Message;

            keyBoardManager.ListenKey();
        }
    }
}
