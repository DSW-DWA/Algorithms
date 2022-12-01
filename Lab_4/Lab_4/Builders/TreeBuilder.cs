using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Lab_4.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_4.Builders
{
    public class TreeBuilder
    {
        public static string Operators = "+-*/";
        public static string Operands = "0123456789";
        // Задание 1
        public static Node CreatTreeFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception($@"Не найден файл! Путь: {Path.GetFileName(path)}");
            }

            var root = new Node();
            try
            {
                var items = File
                    .ReadAllText(path)
                    .Split(' ')
                    .ToList();
        
                items.Sort();

                root = CreateBalancedTree(items, 0, items.Count - 1);
            }
            catch (FormatException e)
            {
                Console.WriteLine("В файле неверный формат данных! В файле должны быть только цифры");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Невозможно считать файл!");
            }

            return root;
        }
        
        private static Node CreateBalancedTree(List<string> items, int start, int end)
        {
            if (end < start) {
                return null;
            }
            var mid = (start + end) / 2;
            var node = new Node(items[mid]);
        
            node.Left = CreateBalancedTree(items, start, mid - 1);
            node.Right = CreateBalancedTree(items, mid + 1, end);
        
            return node;
        }
        private static bool checkOperand(Object operand)
        {
            if (operand.GetType() == typeof(Node))
                return true;

            var number = (char)operand;
            return Operands.IndexOf(number) != -1;
        }

        private static bool checkOperator(Object operatorChar)
        {
            var arithmetic = (char)operatorChar;

            return Operators.IndexOf(arithmetic) != -1;
        }
        public static Node CreatTreeOfArithmeticExpression(string expression)
        {
            if (expression == null || expression.Length == 0)
            {
                throw new Exception("Пустая строка");
            }

            if (expression[0] != '(')
            {
                expression = $"({expression})";
            }

            return  _CreatTreeOfArithmeticExpression(expression);
        }

        private static Node _CreatTreeOfArithmeticExpression(string s)
        {
            if (s[0] != '(')
            {
                return new Node(s);
            }
            else
            {
                var indOp = -1;
                var operators = Regex.Matches(s,@"[+*\/-]");
                foreach (var ind in operators)
                {
                    var match = (Match)ind;
                    var i = match.Index;
                    if (s[i - 1] != '(')
                    {
                        indOp = i;
                        break;
                    }
                }
                var leftNum = "";
                var rightNum = "";
                for (var i = 1; i < indOp; i++)
                {
                    if (s[i] != '(' && s[i] != ')')
                    {
                        leftNum += s[i];
                    }
                }
                for (var i = indOp + 1; i < s.Length; i++)
                {
                    if (s[i] != '(' && s[i] != ')')
                    {
                        rightNum += s[i];
                    }
                }
                var operatorsLeft = Regex.Matches(leftNum, @"[+*\/-]");
                foreach (Match o in operatorsLeft)
                {
                    if (o.Index != 0 && o.Value != '-'.ToString())
                    {
                        leftNum += ")";
                        leftNum = "(" + leftNum;
                    }
                }
                var operatorsRight = Regex.Matches(rightNum, @"[+*\/-]");
                foreach (Match o in operatorsRight)
                {
                    if (o.Index != 0 && o.Value != '-'.ToString())
                    {
                        rightNum += ")";
                        rightNum = "(" + rightNum;
                    }
                }
                var node = new Node(s[indOp].ToString());
                node.Left = _CreatTreeOfArithmeticExpression(leftNum);
                node.Right = _CreatTreeOfArithmeticExpression(rightNum);
                
                return node;
            }
        }

        public static double? SolveExpressionTree(Node node)
        {
            if (node.IsLeaf()) return Convert.ToDouble(node.Value);
            var left = SolveExpressionTree(node.Left);
            var right = SolveExpressionTree(node.Right);
            if (node.Value == "+") return left + right;
            if (node.Value == "-") return left - right;
            if (node.Value == "*") return left * right;
            if (node.Value == "/") return left / right;
            return null;
        }
    }
}