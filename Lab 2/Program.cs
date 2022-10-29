using System.Net.Mime;
using System;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Choose 1-4 tasks");
                var taskNum = Console.ReadLine();

                switch(taskNum)
                {
                    case "1":
                    {
                        var FN = new FibonacciNumbers(35);
                        var start = DateTime.Now;
                        FN.Bine(35);
                        var finish = DateTime.Now;
                        var timeWork = finish - start;
                        Console.WriteLine($"Time work of Bine: {timeWork.Ticks}");

                        start = DateTime.Now;
                        FN.DynamicDown(35);
                        finish = DateTime.Now;
                        timeWork = finish - start;
                        Console.WriteLine($"Time work of DynamicDown: {timeWork.Ticks}");

                        start = DateTime.Now;
                        FN.DynamicUp(35);
                        finish = DateTime.Now;
                        timeWork = finish - start;
                        Console.WriteLine($"Time work of DynamicUp:{timeWork.Ticks}");

                        start = DateTime.Now;
                        FN.DivideAndConquer(35);
                        finish = DateTime.Now;
                        timeWork = finish - start;
                        Console.WriteLine($"Time work of DivideAndConquer:{timeWork.Ticks}");

                        start = DateTime.Now;
                        FN.Iterationnal(35);
                        finish = DateTime.Now;
                        timeWork = finish - start;
                        Console.WriteLine($"Time work of Iterationnal:{timeWork.Ticks}");
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("Enter the max weight of backpack. (integer number)");
                        var size = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the number of items for backpack. (integer number)");
                        var N = Convert.ToInt32(Console.ReadLine());
                        List<ItemOfBackpack> stuff = new List<ItemOfBackpack>();
                        for (int i = 0; i < N; i++)
                        {
                            Console.WriteLine("Enter the weight(integer number) & price(integer number) & name of item for backpack. (Sample: 10 4 Toy)");
                            var input = Console.ReadLine();
                            if (input == null) 
                            {
                                throw new Exception("You enter the empty string");
                            }
                            var infoOfItem = input.Split(" ");
                            stuff.Add(new ItemOfBackpack(Convert.ToInt32(infoOfItem[0]), Convert.ToInt32(infoOfItem[1]),infoOfItem[2]));
                        }
                        var backpack = new Backpack(stuff, size);
                        Console.WriteLine("Now your backpack is empty and we solving your problem...");
                        backpack.ResolveBackpackProblem();
                        Console.WriteLine("We solving your problem. The items which we took:");
                        backpack.ItemsOfBackpack.ForEach(x => Console.WriteLine($"{x.Name} Weight-{x.Weight} Price-{x.Price}"));
                        break;
                    }
                    case "3":
                    {
                        Console.WriteLine("Enter the number of discs to use. (3-10, integer number)");
                        var discs = Convert.ToInt32(Console.ReadLine());
                        Tower tower = new Tower(discs);
                        tower.SolveTower();
                        Console.WriteLine($"Total moves: {tower.Moves}");
                        break;
                    }
                    case "4":
                    {
                        Console.WriteLine("Put your file in the Lab 2 folder. Enter the exact same name of file.");
                        var Name = Console.ReadLine();
                        if (Name == null)
                        {
                            throw new Exception("You enter the empty string");
                        }
                        var Turtle = new  Turtle(Name);
                        Turtle.Solving();
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("You select non-correct task");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Program can't working:");
                Console.WriteLine(e.Message);
            }
        }
    }
}