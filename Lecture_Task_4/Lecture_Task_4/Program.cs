using System;

namespace Lecture_Task_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var items = new int[] { 1, 7, 2, 6, 3, 5, 4 };
            var avlTree = new AVLTree();
            foreach (var item in items)
            {
                avlTree.Add(item);
            }
            Console.WriteLine("Итог");
            BTreePrinter.Print(avlTree.Root);
        }
    }
}