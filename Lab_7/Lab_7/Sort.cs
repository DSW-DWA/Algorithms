using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab_7
{
    public class Sort
    {
        private static ArrayItem[] GenerateRandomArray(int N)
        {
            var r = new Random();
            var rawData = new ArrayItem[N];
            for (var i = 0; i < N; i++)
            {
                rawData[i]=new ArrayItem(r.Next(-2*N,2*N));
            }
            return rawData;
        }
        private static ArrayItemWithАdditions[] GenerateRandomArrayWithAdditional(int N)
        {
            var r = new Random();
            var rawData = new ArrayItemWithАdditions[N];
            for (var i = 0; i < N; i++)
            {
                rawData[i] = new ArrayItemWithАdditions(r.Next(-2 * N, 2 * N));
            }
            return InsertBinSort(rawData).Reverse().ToArray();
        }
        public static void Tests(int N)
        {
            // var rawArray1 = GenerateRandomArrayWithAdditional(N);
            // var start = DateTime.Now;
            // var ans1 = BubbleSort(rawArray1);
            // var end = DateTime.Now;
            // Console.WriteLine($"Время работы сортировки пузырьком {(end-start).Ticks} при N = {N}");
            
            // var rawArray2 = GenerateRandomArrayWithAdditional(N);
            // start = DateTime.Now;
            // var ans2 = ShakerSort(rawArray2);
            // end = DateTime.Now;
            // Console.WriteLine($"Время работы шейкер сортировки {(end-start).Ticks} при N = {N}");
            //
            // var rawArray3 = GenerateRandomArrayWithAdditional(N);
            // start = DateTime.Now;
            // var ans3 = ChoiceSort(rawArray3);
            // end = DateTime.Now;
            // Console.WriteLine($"Время работы сортировки выбором {(end-start).Ticks} при N = {N}");
            //
            // var rawArray4 = GenerateRandomArrayWithAdditional(N);
            // start = DateTime.Now;
            // var ans4 = InsertSort(rawArray4);
            // end = DateTime.Now;
            // Console.WriteLine($"Время работы сортировки вставками {(end-start).Ticks} при N = {N}");
            //
            // var rawArray5 = GenerateRandomArrayWithAdditional(N);
            // start = DateTime.Now;
            // var ans5 = InsertBinSort(rawArray5);
            // end = DateTime.Now;
            // Console.WriteLine($"Время работы сортировки бин. вставками {(end-start).Ticks} при N = {N}");
            
            var rawArray5 = GenerateRandomArray(N);
            var start = DateTime.Now;
            var ans5 = ShellSort(rawArray5,2);
            var end = DateTime.Now;
            Console.WriteLine($"Время работы сортировки Шелла {(end-start).Ticks} при N = {N} и M = {2}");
            
            var rawArray6 = GenerateRandomArray(N);
            start = DateTime.Now;
            var ans6 = ShellSort(rawArray5,4);
            end = DateTime.Now;
            Console.WriteLine($"Время работы сортировки Шелла {(end-start).Ticks} при N = {N} и M = {4}");
            
            var rawArray7 = GenerateRandomArray(N);
            start = DateTime.Now;
            var ans7 = ShellSort(rawArray5,9);
            end = DateTime.Now;
            Console.WriteLine($"Время работы сортировки Шелла {(end-start).Ticks} при N = {N} и M = {9}");
            
            var rawArray8 = GenerateRandomArray(N);
            start = DateTime.Now;
            var ans8 = ShellSort(rawArray5,16);
            end = DateTime.Now;
            Console.WriteLine($"Время работы сортировки Шелла {(end-start).Ticks} при N = {N} и M = {16}");
        }

        private static ArrayItem[] BubbleSort(ArrayItem[] data)
        {
            var N = data.Length;
            for (var i = N; i > 2; i--)
            {
                for (var j = 0; j < i - 1; j++)
                {
                    if (data[j].Key > data[j + 1].Key)
                    {
                        Swap(ref data[j], ref data[j+1]);
                    }
                }
            }

            return data;
        }
        private static ArrayItemWithАdditions[] BubbleSort(ArrayItemWithАdditions[] data)
        {
            var N = data.Length;
            for (var i = N; i > 2; i--)
            {
                for (var j = 0; j < i - 1; j++)
                {
                    if (data[j].Key > data[j + 1].Key)
                    {
                        Swap(ref data[j], ref data[j+1]);
                    }
                }
            }

            return data;
        }
        private static ArrayItem[] ShakerSort(ArrayItem[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j].Key > array[j + 1].Key)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1].Key > array[j].Key)
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
        private static ArrayItemWithАdditions[] ShakerSort(ArrayItemWithАdditions[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j].Key > array[j + 1].Key)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1].Key > array[j].Key)
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
        private static ArrayItem[] ChoiceSort(ArrayItem[] array)
        {
            
            for (var i = 0; i < array.Length - 1; i++)
            {
                var mIndex = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[mIndex].Key < array[j].Key)
                    {
                        mIndex = j;
                    }
                }
                Swap(ref array[i],ref array[mIndex]);
            }

            return array;
        }
        private static ArrayItemWithАdditions[] ChoiceSort(ArrayItemWithАdditions[] array)
        {
            
            for (var i = 0; i < array.Length - 1; i++)
            {
                var mIndex = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[mIndex].Key < array[j].Key)
                    {
                        mIndex = j;
                    }
                }
                Swap(ref array[i],ref array[mIndex]);
            }

            return array;
        }
        private static ArrayItem[] InsertSort(ArrayItem[] array)
        {
            for (var i = 2; i < array.Length; i++)
            {
                var y = array[i];
                var j = i - 1;
                while (j >= 1 && y.Key < array[j].Key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = y;
            }

            return array;
        }
        private static ArrayItemWithАdditions[] InsertSort(ArrayItemWithАdditions[] array)
        {
            for (var i = 2; i < array.Length; i++)
            {
                var y = array[i];
                var j = i - 1;
                while (j >= 1 && y.Key < array[j].Key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = y;
            }

            return array;
        }
        private static ArrayItem[] InsertBinSort(ArrayItem[] array)
        {
            for (var i = 2; i < array.Length; i++)
            {
                var y = array[i];
                var l = 1;
                var r = i - 1;
                while (l < r)
                {
                    var m = (l + r) / 2;
                    if (array[m].Key < y.Key)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }

                for (var j = i; j > l + 1; j--)
                {
                    array[l] = y;
                }

                array[l] = y;
            }

            return array;
        }
        private static ArrayItemWithАdditions[] InsertBinSort(ArrayItemWithАdditions[] array)
        {
            for (var i = 2; i < array.Length; i++)
            {
                var y = array[i];
                var l = 1;
                var r = i - 1;
                while (l < r)
                {
                    var m = (l + r) / 2;
                    if (array[m].Key < y.Key)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }

                for (var j = i; j > l + 1; j--)
                {
                    array[l] = y;
                }

                array[l] = y;
            }

            return array;
        }
        private static ArrayItem[] ShellSort(ArrayItem[] array, int m)
        {
            var d = array.Length / m;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d].Key > array[j].Key))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / m;
            }

            return array;
        }
        static void Swap(ref ArrayItem e1, ref ArrayItem e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        static void Swap(ref ArrayItemWithАdditions e1, ref ArrayItemWithАdditions e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
    }
}