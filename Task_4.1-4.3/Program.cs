using System;

namespace S
{

    class NumberArray
    {
        public int[] array;
        public int size;
        public NumberArray(NumberArray arr)
        {
            this.array = (int[])arr.array.Clone();
            this.size = arr.size;
        }
        public NumberArray(int size)
        {
            this.size = size;
            array = new int[size];
        }
        public NumberArray(int[] arr)
        {
            array = (int[])arr.Clone();
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
        
        public static int Partition(int[] array, int start, int end)
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

            var pivotIndex = Partition(array, minIndex, maxIndex);
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
            SortDelegate Sort = new SortDelegate(NumberArray.SelectionSort); 
            int[] arr = new int[2];
            arr[1] = 0;
            arr[0] = 2;
            int[] newarr = Sort(arr);
            Console.WriteLine(newarr[1]);
        }
    }
}
