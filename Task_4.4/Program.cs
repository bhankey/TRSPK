using System;
using System.Diagnostics;
namespace S
{

    class NumberArray
    {
        public int[] array;
        public int size;
        public NumberArray(NumberArray arr)
        {
            this.array = arr.array;
            this.size = arr.size;
        }
        public NumberArray(int size)
        {
            this.size = size;
            array = new int[size];
        }
        public NumberArray(int[] arr)
        {
            array = arr;
            size = array.Length;
        }
        public NumberArray()
        {
            array = new int[0];
            size = 0;
        }
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
        public static int IndexOfMin(int[] array, int n)
        {
            int result = n;
            for (var i = n; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        public static void Swap(ref int x, ref int y)
        {
            (x, y) = (y, x);
        }

        public static int[] SelectionSort(int[] array, int currentIndex = 0)
        {
            if (currentIndex == array.Length)
                return array;

            var index = IndexOfMin(array, currentIndex);
            if (index != currentIndex)
            {
                Swap(ref array[index], ref array[currentIndex]);
            }

            return SelectionSort(array, currentIndex + 1);
        }
        public static int[] SelectionSort(int[] array)
        {
            return SelectionSort(array, 0);
        }
        public static int partition(int[] array, int start, int end)
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        public static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

    }

    class S
    {
        public delegate int[] SortDelegate(int[] arr);
        static void Main(string[] args)
        {
            Random BlessRNG = new Random();
            SortDelegate Qsort = new SortDelegate(NumberArray.QuickSort);
            SortDelegate Selsort = new SortDelegate(NumberArray.SelectionSort);
            int[] array = new int[40];
            for (int i=0; i<array.Length; i++)
            {
                array[i] = BlessRNG.Next()%100;
                Console.Write(array[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.Write("Выберите метод сортировки: ");
            int flag = int.Parse(Console.ReadLine());
            int[] newarr;
            Stopwatch stopwatch = new Stopwatch();
            if (flag == 1)
            {
                stopwatch.Start();
                newarr = Qsort(array);
                stopwatch.Stop();
            } else
            {
                stopwatch.Start();
                newarr = Selsort(array);
                stopwatch.Stop();
            }
            for (int i=0; i<newarr.Length; i++)
            {
                Console.Write(array[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.Write("Затрачено тактов на сортировку: ");
            Console.Write(stopwatch.ElapsedTicks);
        }
    }
}
