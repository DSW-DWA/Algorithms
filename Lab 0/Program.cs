using System;

namespace Lab0 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание");
            var num = Convert.ToInt32(Console.ReadLine());
            switch(num)
            {
                case 1:
                    var task1 = new Task1();
                    Console.WriteLine("Введите n");
                    var n1 = Convert.ToInt32(Console.ReadLine());
                    task1.list = new List<Tuple<int, int>>();
                    task1.n = n1;
                    Console.WriteLine("Введите n пар");
                    for (int i = 0; i < n1; i++)
                    {
                        string[] arr = Console.ReadLine().Split(' ');
                        var tupe = new Tuple<int, int>(Convert.ToInt32(arr[0]),Convert.ToInt32(arr[1]));
                        task1.Add(tupe);
                    }
                    Console.WriteLine("Ответ:");
                    task1.list.ForEach(x => Console.WriteLine(x.Item1 + " " + x.Item2));
                    break;
                case 2:
                    var task2 = new Task2();
                    Console.WriteLine("Введите n");
                    var n2 = Convert.ToInt32(Console.ReadLine());
                    task2.n= n2;
                    Console.WriteLine("Всего делителей: "+ task2.AllDivisors());
                    Console.WriteLine("Простых делителей: "+ task2.PrimeDivisors());
                    break;
                case 3:
                    var task3 = new Task3();
                    task3.ReadData("data.txt");
                    Console.WriteLine("Введите L и R");
                    var l = Convert.ToInt32(Console.ReadLine());
                    var r = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(task3.FindMax(l,r));
                    break;
            }
        }
    }
}