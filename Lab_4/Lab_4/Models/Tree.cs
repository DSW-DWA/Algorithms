using System;
using System.ComponentModel;

namespace Lab_4.Models
{
    public class Tree
    {
        public Node? Root { get; set; }
        private int _leafCount;
        public Tree()
        {
            Root = new Node();
            _leafCount = 0;
        }
        public Tree(Node root)
        {
            Root = root;
            _leafCount = 0;
        }
        public void Print()
        {
            if (Root == null)
            {
                Console.WriteLine("Дерево пустое");
            }
            else
            {
                PrintTree(Root, "", true);
            }
        }
        private void PrintTree(Node node, string indent, bool lastInString)
        {
            Console.WriteLine(indent + "+- " + node.Value);
            indent += lastInString ? "   " : "|  ";
            
            if (node.Left != null ) PrintTree(node.Left, indent, node.ChildCount() != 2 ? true : false);
            if (node.Right != null ) PrintTree(node.Right, indent, node.ChildCount() == 2 ? true : false);
        }

        public int LeafCount()
        {
            if (Root == null)
            {
                throw new Exception("Дерево пустое");
            }
            LeafCount(Root);
            return _leafCount;
        }
        // Добавил 2 задание
        private void LeafCount(Node node)
        {
            if (node.IsLeaf())
            {
                _leafCount++;
            }

            if (node.Left != null) LeafCount(node.Left);
            if (node.Right != null) LeafCount(node.Right);
        }
    }
}