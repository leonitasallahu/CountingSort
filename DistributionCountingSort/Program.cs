using System;

namespace CountingSort
{
    class CountingSort
    {
        static void Sort(int[] array)
        {
            int length = array.Length;

            int[] output = new int[length];

            int[] count = new int[1000000];

            for (int i = 0; i < 100; ++i)
            {
                count[i] = 0;
            }
            for (int i = 0; i < length; ++i)
            {
                ++count[array[i]];
            }

            for (int i = 1; i <= 99; ++i)
            {
                count[i] += count[i - 1];
            }

            for (int i = length - 1; i >= 0; i--)
            {
                output[count[array[i]] - 1] = array[i];
                --count[array[i]];
            }

            for (int i = 0; i < length; ++i)
            {
                array[i] = output[i];
            }
        }

        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int[] array = new int[1000000];
            Random RandomNumber = new Random();


            for (int i = 0; i < 1000000; i++)
            {
                array[i] = RandomNumber.Next(1, 1000000);
            }

            Console.WriteLine("Counting Sort");

            //Console.Write("Vargu fillestar: ");
            //Print(array);

            Sort(array);

            //Console.Write("Vargu i sortuar: ");
            //Print(array);
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("Elapsed Time is {0} ms", elapsedMs);
            Console.ReadLine();
        }

        private static void Print(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
