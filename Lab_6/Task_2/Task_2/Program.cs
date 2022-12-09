using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            HashTableBuilder.CreateHashTableBuilder(5000);
            Console.WriteLine();
            HashTableBuilder.CreateHashTableBuilder(10000);
            Console.WriteLine();
            HashTableBuilder.CreateHashTableBuilder(20000);
        }
    }
}