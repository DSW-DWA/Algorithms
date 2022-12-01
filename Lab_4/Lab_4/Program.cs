using System;
using Lab_4.Models;
using Lab_4.Builders;

namespace Lab_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Tree(TreeBuilder.CreatTreeFromFile(@"data.txt"));
            tree.Print();
            var leafCount = tree.LeafCount();
            Console.WriteLine($"Колл-во листьев в дереве: {leafCount}");

            var tree1 = new Tree(TreeBuilder.tmp("(-7-(-2*(-3)))"));
            tree1.Print();
            Console.WriteLine(TreeBuilder.SolveExpressionTree(tree1.Root));
        }
    }
}