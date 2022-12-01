using System.Xml;

namespace Lab_3_fix.Tasks.Task_1;

public class List
{
		// добавил 24, 1, 7, 14, 22
		private Node _first;
		private Node _last;
        private int _lenght;
        public List()
        {
	        _lenght = 0;
        }
        /// <summary>
        /// Получает Node по позиции
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Node GetNode(int ind)
        {
	        ind--;
            if (_first == null)
            {
                throw new Exception("Нельзя получить элемент в пустом списке");
            }
            var ans = _first;
            while(ind > 0)
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
			if (_lenght == 0)
			{
				_last = _first;
			}
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
		/// <summary>
		/// Удаляет элементы с условием [first;last)
		/// </summary>
		/// <param name="first"></param>
		/// <param name="last"></param>
		/// <exception cref="Exception"></exception>
        public void Delete(int first, int last)
        {
            if (_first == null) {
				throw new Exception("нельзя удалить элемент из пустого списка");
			}
            var firstNode = GetNode(first);
            var lastNode = GetNode(last);
            firstNode = firstNode.prev;
            if (firstNode == null)
            {
	            _first = lastNode;
            }
            else
            {
	            firstNode.next = lastNode;   
            }
        }
		/// <summary>
		///	Удаляет конкретный элемент node у котрого известные его предыдущий и последующий элемент
		/// </summary>
		/// <param name="node"></param>
		/// <exception cref="Exception"></exception>
		public void Delete(Node node)
        {
	        if (_first == null) {
		        throw new Exception("нельзя удалить элемент из пустого списка");
	        }

	        var nd = _first;
	        while (nd != null)
	        {
		        if (nd == node)
		        {
			        var ndBefore = nd.prev;
			        var ndAfter = nd.next;
			        if (ndBefore == null)
			        {
				        _first = ndAfter;
			        }
			        else
			        {
				        ndBefore.next = ndAfter;
			        }
			        break;
		        }
		        nd = nd.next;
	        }
        }
		/// <summary>
		/// Находит последний элемент у которого с значением value, возращает null если элемент не найден 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Node FindLastOrDefault(int value)
		{
			var ans = new Node();
			for (var node = _last; node != null; node = node.prev)
			{
				if (node.value == value)
				{
					return node;
				}
			}

			return null;
		}
		public void Print() 
        {
			for (var node = _first; node != null; node = node.next) 
			{
				Console.Write($"{node.value} ");
			}
			Console.WriteLine();
		}
        public void PrintReversed()
        {
            for (var node = _last; node != null; node = node.prev)
            {
                Console.Write($"{node.value} ");
            }
            Console.WriteLine();
        }

        public void Reverse()
        {
	        if (_first == null || _first.next == null)
	        {
		        return;
	        }
	        var node = _first.next.next;
	        (_first.value, _last.value) = (_last.value, _first.value);
	        while (node.next != null && node != null)
	        {
		        var nodeNext = node.next;
		        var nodePrev = node.prev;
		        node.next = nodePrev;
		        node.prev = nodeNext;
		        node = nodeNext;
	        }
        }

        public int GetMinValue()
        {
	        if (_first == null)
	        {
		        throw new Exception("Нельзя найти минимальное значение в пустом списке");
	        }

	        var m = _first.value;
	        for (var node = _first.next; node != null; node = node.next)
	        {
		        if (node.value < m)
		        {
			        m = node.value;
		        }
	        }

	        return m;
        }
}