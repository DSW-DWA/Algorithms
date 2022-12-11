using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lecture_Task_3
{
    public class HuffmanTree
    {
        private List<Node> _nodes = new List<Node>();
        public Node Root { get; set; }
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();
        public void Build(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }
            
            foreach (KeyValuePair<char, int> symbol in Frequencies)
            {
                Console.Write($"{symbol.Key} - {symbol.Value}; ");
                _nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            }
            Console.WriteLine();
            Console.WriteLine("Создаются узлы для дерева:");
            while (_nodes.Count > 1)
            {
                List<Node> orderedNodes = _nodes.OrderBy(node => node.Frequency).ToList();
                
                if (orderedNodes.Count >= 2)
                {
                    List<Node> taken = orderedNodes.Take(2).ToList();
                    
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Left = taken[0],
                        Right = taken[1]
                    };
                    var par = "";
                    if (parent.Parent != null)
                    {
                        par += $"Родителем является корень со значением {parent.Parent.Frequency}.";
                    }
                    Console.WriteLine($"Постороен узел с значением {parent.Frequency}. Его левое знаяение {parent.Left.Frequency}. Его правое знаечение {parent.Right.Frequency}. {par}");
                    parent.Left.Parent = parent;
                    parent.Right.Parent = parent;
                    _nodes.Remove(taken[0]);
                    _nodes.Remove(taken[1]);
                    _nodes.Add(parent);
                }

                this.Root = _nodes.FirstOrDefault();

            }

        }

        public BitArray Encode(string source)
        {
            List<bool> encodedSource = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }

            BitArray bits = new BitArray(encodedSource.ToArray());

            return bits;
        }

        public void PrintAllCode()
        {
            Console.WriteLine("Получившиеся коды:");
            foreach (var keyValuePair in Frequencies)
            {
                Console.Write($"{keyValuePair.Key} - ");
                List<bool> encodedSymbol = this.Root.Traverse(keyValuePair.Key, new List<bool>());
                foreach (bool bit in encodedSymbol)
                {
                    Console.Write((bit ? 1 : 0));
                }
                Console.WriteLine();
            }
        }
        public string Decode(BitArray bits)
        {
            Node current = this.Root;
            string decoded = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Symbol;
                    current = this.Root;
                }
            }

            return decoded;
        }

        public int Height()
        {
            return Height(Root, 0);
        }
        private int Height(Node root, int height)
        {
            if (root == null) return height-1;
            return Math.Max(Height(root.Left, height + 1), Height(root.Right, height + 1));
        }

        public bool IsLeaf(Node node)
        {
            return (node.Left == null && node.Right == null);
        }
        
    }
}