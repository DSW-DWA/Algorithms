namespace Lab3
{
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
            var ans =_first;
            for (var node = ans; ind > 0; ind--)
            {
                ans = ans.next;
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
            firstNode.next = lastNode;
            lastNode.next = null;
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
}