namespace Lab_3_fix.Tasks.Task_2;

public class SieveOfEratosthenes
{
    public static int[] GetPrimeNumbersUseArray(int n)
    {
        if (n < 1)
        {
            throw new Exception("Введенное N не соответствует условиям задачи");
        }
        var numbers = Enumerable.Range(1,n).ToArray();
        var start = DateTime.Now;
        for (var i = 2; i < Math.Floor(Math.Sqrt(n))+1; i++)
        {
            if (numbers[i-1] != -1)
            {
                for (var j = i; j <= n / i; j++)
                {
                    numbers[i * j - 1] = -1;
                }
            }
        }
        var end = DateTime.Now;
        Console.WriteLine($"Время работы алгоритма \"Решето Эротосфена\" реализованого через массив: {(end-start).Ticks}");
        return numbers;
    }
    public static LinkedList<int> GetPrimeNumbersUseLinkedList(int n)
    {
        if (n < 1)
        {
            throw new Exception("Введенное N не соответствует условиям задачи");
        }
        var tmp = Enumerable.Range(1, n).ToArray();
        var numbers = new LinkedList<int>(tmp);
        var start = DateTime.Now;
        for (var i = 2; i < Math.Floor(Math.Sqrt(n))+1; i++)
        {
            if (numbers.Find(i) != null)
            {
                for (var j = i; j <= n / i; j++)
                {
                    var node = numbers.Find(i * j);
                    if (node != null)
                    {
                        node.Value = -1;
                    }
                }
            }
        }
        var end = DateTime.Now;
        Console.WriteLine($"Время работы алгоритма \"Решето Эротосфена\" реализованого через связанный список: {(end-start).Ticks}");
        return numbers;
    }
}