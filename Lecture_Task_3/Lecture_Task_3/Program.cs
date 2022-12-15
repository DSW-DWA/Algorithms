using System;
using System.Collections;
using System.IO;

namespace Lecture_Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            var input = Console.ReadLine();
            File.WriteAllText("text.txt",input);
            HuffmanTree huffmanTree = new HuffmanTree();

            // Создаю дерево Хаффмана
            huffmanTree.Build(input);
            
            Console.WriteLine("Получившееся дерево Хаффмана:");
            Console.WriteLine();
            BTreePrinter.Print(huffmanTree.Root);
            huffmanTree.PrintAllCode();
            
            // Получаю закадированную версию строки
            BitArray encoded = huffmanTree.Encode(input);
            
            Console.Write("Закодированное представление: ");
            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");
            }
            Console.WriteLine();

            Console.WriteLine($"Раскодированное предстваление: {huffmanTree.Decode(encoded)}");
            
            // Записываю закадированную версию строки в битовый файл
            byte [] bytes = new byte[encoded.Length / 8 + ( encoded.Length % 8 == 0 ? 0 : 1 )];
            encoded.CopyTo( bytes, 0 );
            File.WriteAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "../../result.bin"),bytes);
            Console.WriteLine($"Битовое представление закодированной строки записано в папку проекта в файл result.bin");
            
            Console.WriteLine();
            var fi1 = new FileInfo("text.txt");
            var fi2 = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "../../result.bin"));
            Console.WriteLine($"Изначальный размер строки (колл-во байт):{fi1.Length}{Environment.NewLine}Размер закадированной строки (колл-во байт):{fi2.Length}{Environment.NewLine}Сэкономили {Math.Round((((double)(fi1.Length - fi2.Length)) / fi1.Length) * 100,2)}% байт");
        }
    }
}
