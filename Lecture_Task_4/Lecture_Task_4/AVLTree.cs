using System;

namespace Lecture_Task_4
{
    public class AVLTree
    {
        public Node Root;
        public AVLTree()
        {
        }
        public void Add(int Data)
        {
            Node newItem = new Node(Data);
            if (Root == null)
            {
                Root = newItem;
            }
            else
            {
                Root = RecursiveInsert(Root, newItem);
            }
            BTreePrinter.Print(Root);
        }
        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Data < current.Data)
            {
                current.Left = RecursiveInsert(current.Left, n);
                current = balance_tree(current);
            }
            else if (n.Data > current.Data)
            {
                current.Right = RecursiveInsert(current.Right, n);
                current = balance_tree(current);
            }
            return current;
        }
        private Node balance_tree(Node current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        public void Delete(int target)
        {
            BTreePrinter.Print(Root);
            Root = Delete(Root, target);
            BTreePrinter.Print(Root);
        }
        private Node Delete(Node current, int target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                //Left subtree
                if (target < current.Data)
                {
                    current.Left = Delete(current.Left, target);
                    if (balance_factor(current) == -2)//here
                    {
                        if (balance_factor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //Right subtree
                else if (target > current.Data)
                {
                    current.Right = Delete(current.Right, target);
                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.Right != null)
                    {
                        //delete its inorder successor
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Data = parent.Data;
                        current.Right = Delete(current.Right, parent.Data);
                        if (balance_factor(current) == 2)//rebalancing
                        {
                            if (balance_factor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.Left != null
                        return current.Left;
                    }
                }
            }
            return current;
        }
        public void Find(int key)
        {
            if (Find(key, Root).Data == key)
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }
        private Node Find(int target, Node current)
        {
     
            if (target < current.Data)
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Left);
            }
            else
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Right);
            }
     
        }
        public void DisplayTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(Root);
            Console.WriteLine();
        }
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.Left);
                Console.Write("({0}) ", current.Data);
                InOrderDisplayTree(current.Right);
            }
        }
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.Left);
                int r = getHeight(current.Right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int balance_factor(Node current)
        {
            int l = getHeight(current.Left);
            int r = getHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }
        private Node RotateRR(Node parent)
        {
            BTreePrinter.Print(Root);
            Console.WriteLine("RR Поворот");
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            BTreePrinter.Print(Root);
            Console.WriteLine("LL Поворот");
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            BTreePrinter.Print(Root);
            Console.WriteLine("LR Поворот и его следствия:");
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            BTreePrinter.Print(Root);
            Console.WriteLine("RL Поворот и его следствия:");
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}