using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    public class HashTableBuilder
    {
        public static void CreateHashTableBuilder(int N)
        {
            var r = new Random();
            var numbers = new List<int>();
            var hashList = new List<int>[N/100];
            var minHashList = N + 1;
            var maxHashList = -1;
            for (var i = 0; i<N;i++)
            {
                var number = r.Next(1, 4 * N);
                if (numbers.Contains(number)) continue;
                numbers.Add(number);
                var hash = GetHash(number,N);
                if (hashList[hash] == null)
                {
                    hashList[hash] = new List<int>();
                    hashList[hash].Add(number);
                }
                else
                {
                    hashList[hash].Add(number);
                }
                maxHashList = Math.Max(hashList[hash].Count, maxHashList);
            }
            
            Console.WriteLine($"Максимальная длина при N = {N} - {maxHashList}");
            Console.WriteLine($"Минимальная длина при N = {N} - {hashList.Min(x => x.Count)}");
        }

        private static int GetHash(int n, int N)
        {
            return (n + 23) % (N/100);
        }
    }
}