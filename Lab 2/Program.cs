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
               int discs = 0;

                while (discs < 3 || discs > 10)
                {
                    Console.WriteLine("Enter the number of discs to use. (3-10)");
                    discs = Convert.ToInt32(Console.ReadLine());
                }
                Tower tower = new Tower(discs);
                tower.SolveTower();
                Console.WriteLine($"Total moves: {tower.Moves}");
            }
            catch
            {
                Console.WriteLine("You entered non-correct data, try again");
            }
        }
    }
}