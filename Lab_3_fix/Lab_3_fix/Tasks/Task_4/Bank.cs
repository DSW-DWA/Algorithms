using System.Net.Sockets;

namespace Lab_3_fix.Tasks.Task_4;

public static class Bank
{
    private static List<Queue<Human>> _queues;
    private static int _workSpeed;
    private static int _numOfClients;
    
    public static void BankStartWorkDay (int m = 5, int n = 20)
    {
        var rand = new Random(); 
        _queues = new List<Queue<Human>>();
        for (var i = 0; i < m; i++)
        {
            _queues.Add(new Queue<Human>());
        }
        _workSpeed = rand.Next(1,Convert.ToInt32(Math.Round(Math.Sqrt(n/2))));
        _numOfClients = n;
        for (var i = 0; i < n; i++)
        {
            var human = new Human();
            var numOfQueue = rand.Next(m);
            _queues[numOfQueue].Enqueue(human);
            Console.WriteLine($"Человек с именем {human.Name} вошел в конец очереди №{numOfQueue+1}");
            if (i % _workSpeed == 0)
            {
                numOfQueue = rand.Next(m);
                if (_queues[numOfQueue].Count > 0)
                {
                    var end = _queues[numOfQueue].Peek();
                    _queues[numOfQueue].Dequeue();
                    _numOfClients--;
                    Console.WriteLine($"В очереди №{numOfQueue+1} был обслужен человек {end.Name}");
                }
            }
        }
        Console.WriteLine("Время приема клиентов закончено");
        for (var i = 0; i < m; i++)
        {
            Console.WriteLine($"В очереди №{i+1} стоит {_queues[i].Count} человек(-а)");
        }
        BankFinishWorkDay();
    }

    private static void BankFinishWorkDay()
    {
        var rand = new Random();
        while (_numOfClients > 0)
        {
            var numOfQueue = rand.Next(_queues.Count);
            if (_queues[numOfQueue].Count > 0)
            {
                var end = _queues[numOfQueue].Peek();
                _queues[numOfQueue].Dequeue();
                _numOfClients--;
                Console.WriteLine($"В очереди №{numOfQueue+1} был обслужен человек {end.Name}");
            }
        }
        Console.WriteLine("Все клиенты обслуженны");
    }
}