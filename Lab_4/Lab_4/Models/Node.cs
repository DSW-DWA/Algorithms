using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Runtime.CompilerServices;

namespace Lab_4.Models
{
    public class Node
    {
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public string Value { get; set; }

        public Node()
        {
        }
        public Node(string value)
        {
            Value = value;
            Right = null;
            Left = null;
        }
        public Node(Node left, Node right, string value)
        {
            Left = left;
            Right = right;
            Value = value;
        }

        public Node(Node parent, Node left, Node right, string value)
        {
            Left = left;
            Right = right;
            Value = value;
        }
        public bool IsLeaf()
        {
            return (Left == null) && (Right == null); 
        }
        public int ChildCount()
        {
            return Convert.ToInt32(Left != null) + Convert.ToInt32(Right != null);
        }
    }
}