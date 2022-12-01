namespace Lab_3_fix.Tasks.Task_1;

public class ListStuff
{
    public static void Debug() 
    {
        var list = new List();
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
        list.Print(); // 1 3
        
        list.AddFirst(2);
        
        list.Print(); // 2 1 3
        list.Reverse();
        list.Print(); // 3 1 2
        
        Console.WriteLine(list.GetMinValue());
    }
}