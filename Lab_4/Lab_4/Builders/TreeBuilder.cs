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
        public static Node CreatTreeOfArithmeticExpression(string expression)
        {
            if (expression == null || expression.Length == 0)
            {
                throw new Exception("Пустая строка");
            }

            return  _CreatTreeOfArithmeticExpression(expression);
        }

        private static Node _CreatTreeOfArithmeticExpression(string s)
        {
            var operators = Regex.Matches(s, @"[+*\/-]");
            if (operators.Count == 0)
            {
                return new Node(s);
            }
            else
            {
               var indOp = -1;
               var operatorsInBrackets = Regex.Matches(s, @"\(((.*?)[+*\/-](.*?))\)");
               foreach (Match @operator in operators)
               {
                   var flag = false;
                   foreach (Match operatorsInBracket in operatorsInBrackets)
                   {
                       var checkOp = Regex.Match(operatorsInBracket.Value, @"[+*\/-]");
                       if (@operator.Index == (operatorsInBracket.Index + checkOp.Index))
                       {
                           flag = true;
                           break;
                       }
                   }
                   if (flag) continue;
                   indOp = @operator.Index;
                   break;
               }

               var leftNum = "";
               var rightNum = "";
               for (var i = 0; i < indOp; i++)
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