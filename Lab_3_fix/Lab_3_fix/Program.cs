using Lab_3_fix.Tasks.Task_1;
using Lab_3_fix.Tasks.Task_2;
using Lab_3_fix.Tasks.Task_4;

namespace Lab_3_fix;
internal class Program
{
    static void Main(string[] args)
    {
        //ListStuff.Debug();
        var ans = JosephusProblem.GetSavePlaceWithArray(9,3);
        var ans1 = JosephusProblem.GetSavePlaceWithLinkedList(9, 3);

        //Bank.BankStartWorkDay();
    }
}