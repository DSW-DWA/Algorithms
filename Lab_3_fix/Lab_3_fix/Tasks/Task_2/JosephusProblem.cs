namespace Lab_3_fix.Tasks.Task_2;

public class JosephusProblem
{
    public static int GetSavePlaceWithLinkedList(int n, int m)
    {
        if (n < 1 || m < 2)
        {
            throw new Exception("Введенное N или M не соответствует условиям задачи");
        }
        var tmp = Enumerable.Range(1, n).ToArray();
        var members = new LinkedList<int>(tmp);
        var node = members.First;
        var start = DateTime.Now;
        while (members.Count > 1)
        {
            for (var i = 0; i < m-1; i++)
            {
                if (node.Next != null)
                {
                    node = node.Next;   
                }
                else
                {
                    node = members.First;
                }
            }

            var nodeNext = new LinkedListNode<int>(1);
            if (node.Next != null)
            {
                nodeNext = node.Next;   
            }
            else
            {
                nodeNext = members.First;
            }
            members.Remove(node);
            node = nodeNext;
        }

        var end = DateTime.Now;
        Console.WriteLine($"Время работы \"Проблемы Иосифа Флавия\" с использованием связонного списка {(end-start).Ticks}");
        return members.Last();
    }

    public static int GetSavePlaceWithArray(int n, int m)
    {
        if (n < 1 || m < 2)
        {
            throw new Exception("Введенное N или M не соответствует условиям задачи");
        }
        var members = Enumerable.Range(1, n).ToArray();
        var delInd = 0;
        var numOfLive = n;
        var start = DateTime.Now;
        while (numOfLive > 1)
        {
            var k = m;
            while (k > 0)
            {
                if (members[delInd] != -1)
                {
                    k--;
                    if (k != 0)
                    {
                        delInd++;
                        if (delInd >= members.Length)
                        {
                            delInd = 0;
                        }   
                    }
                }
                else
                {
                    delInd++;
                    if (delInd >= members.Length)
                    {
                        delInd = 0;
                    }
                }
            }
            Console.WriteLine($"Был убит солдат с номером {members[delInd]}");
            numOfLive--;
            members[delInd] = -1;
        }

        var end = DateTime.Now;
        Console.WriteLine($"Время работы \"Проблемы Иосифа Флавия\" с использованием массива {(end-start).Ticks}");
        return members.First(x => x != -1);
    }
}