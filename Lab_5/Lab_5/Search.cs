using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5
{
    public class Search
    {

        private static List<int> GenerateList(int N)
        {
            var r = new Random();
            return Enumerable.Repeat(1, N).Select(x => r.Next(-N, N)).ToList();
        }
        public static void LineSearch(int M, int N)
        {
            var r = new Random();
            var a = GenerateList(N);
            var start = DateTime.Now;
            for (int i = 0; i < M; i++)
            {
                var ans = LineSearch(a.ToArray(), r.Next(-2 * N, 2 * N));
                if (ans == null) ans = -1;
            }
            var end = DateTime.Now;
            Console.WriteLine($"Время работы линейного поиска при M = {M} N = {N}: {(end-start).Ticks}");
        }

        public static void LineSearchWithBarrier(int M, int N)
        {
            var r = new Random();
            var a = GenerateList(N);
            a.Add(-1);
            var start = DateTime.Now;
            for (int i = 0; i < M; i++)
            {
                var ans = LineSearchWithBarrier(a.ToArray(), r.Next(-2 * N, 2 * N));
            }
            var end = DateTime.Now;
            Console.WriteLine($"Время работы линейного поиска c бареьром при M = {M} N = {N}: {(end-start).Ticks}");
        }

        private static int? LineSearch(int[] a, int b)
        {
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == b) return i;
            }

            return null;
        }
        private static int? LineSearchWithBarrier(int[] a, int b)
        {
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == b) 
                    return i;
                else if (i == a.Length - 1)
                {
                    return a[i];
                }
            }

            return null;
        }

        public static void BinarySearch(int M, int N)
        {
            var r = new Random();
            var a = GenerateList(N);
            a.Sort();
            var b = a.ToArray();
            var start = DateTime.Now;
            for (var i = 0; i < M; i++)
            {
                Array.BinarySearch(b, r.Next(-2 * N, 2 * N));
            }
            var end = DateTime.Now;
            Console.WriteLine($"Время работы бин. поиска при M = {M} N = {N}: {(end-start).Ticks}");
        }

        public static void InterpolationSearch(int M, int N)
        {
            var r = new Random();
            var a = GenerateList(N);
            a.Sort();
            var b = a.ToArray();
            var start = DateTime.Now;
            for (var i = 0; i < M; i++)
            {
                InterpolationSearch(b, r.Next(-2 * N, 2 * N));
            }
            var end = DateTime.Now;
            Console.WriteLine($"Время работы интер. поиска при M = {M} N = {N}: {(end-start).Ticks}");
        }
        private static int InterpolationSearch(int[] sortedArray, int elementToFind)
        {
            int mid, left = 0, right = sortedArray.Length - 1;
            while (sortedArray[left] <= elementToFind && sortedArray[right] >= elementToFind)
            {
                mid = left + ((elementToFind - sortedArray[left]) * (right - left)) / (sortedArray[right] - sortedArray[left]);
                if (sortedArray[mid] < elementToFind) left = mid + 1;
                else if (sortedArray[mid] > elementToFind) right = mid - 1;
                else return mid;
            }

            return -1;
        }
    }
}