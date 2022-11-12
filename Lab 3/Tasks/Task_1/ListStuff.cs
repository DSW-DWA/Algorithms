namespace Lab3
{
    public static class ListStuff
    {
        public static void Debug() 
        {
			var list = new List();
			list.Print(); // пустая строка
			list.AddFirst(3);
			list.AddFirst(2);
			list.AddFirst(1);
			list.Print(); // 1 2 3
            list.PrintReversed(); // 3 2 1

			list.DeleteFirst();
			list.Print(); // 2 3
        	list.PrintReversed(); // 3 2

			list.AddFirst(1);
			list.Print(); // 1 2 3
			list.Delete(2,3);
			list.Print(); // 1 

		}
    }
}