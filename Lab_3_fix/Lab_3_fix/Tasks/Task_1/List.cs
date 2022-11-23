namespace Lab_3_fix.Tasks.Task_1;

public class List
{
    private Node _first;
        private int _lenght;
        public List()
        {
            _lenght = 0;
        }
        public Node GetNode(int ind)
        {
            if (_first == null)
            {
                throw new Exception("Нельзя получить элемент в пустом списке");
            }
            var ans = _first;
            while(ind > 1)
            {
                ans = ans.next;
                if (ans == null)
                {
                    throw new Exception("Вы запросили элемент за приделами списка");
                }
                ind--;
            }
            return ans;
        }
		public void AddFirst(int value)
        {
			Node node = new Node();
			node.next = _first;
			node.value = value;
			_first = node;
			if (_first.next != null) {
				_first.next.prev = _first;
			}
            _lenght++;
		}
		public void DeleteFirst() 
        {
			if (_first == null) {
				throw new Exception("нельзя удалить первый элемент из пустого списка");
			}
			_first = _first.next;
			if (_first != null) {
				_first.prev = null;
			}
            _lenght--;
		}
        public void Delete(int first, int last)
        {
            if (first == null) {
				throw new Exception("нельзя удалить элемент из пустого списка");
			}
            var firstNode = GetNode(first--);
            var lastNode = GetNode(last--);
            firstNode = firstNode.prev;
            lastNode = lastNode.next;
            firstNode.next = lastNode;
        }
		public void Print() 
        {
			var first = true;
			for (var node = _first; node != null; node = node.next) {
				if (!first) {
					Console.Write(" ");
				}
				first = false;
				Console.Write(node.value);
			}
			Console.WriteLine();
		}
        public void PrintReversed()
        {
            var last= new Node();
            for (var node = _first; node != null; node = node.next)
            {
                last = node;
            }
            for (var node = last; node != null; node = node.prev)
            {
                Console.Write($"{node.value} ");
            }
            Console.WriteLine();
        }
}