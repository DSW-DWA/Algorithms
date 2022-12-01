namespace Lab_3_fix.Tasks.Task_5;

public class PriorityQueueDelete
{
    private List<Item> _items;

    public PriorityQueueDelete()
    {
        _items = new List<Item>();
    }

    public void Insert(Item item)
    {
        _items.Add(item);
    }

    public void Delete()
    {
        if (_items.Count == 0)
        {
            throw new Exception("Не возможно удалить из пустой очереди");
        }
        var item = _items.OrderBy(x => x.Priority).Last();
        _items.Remove(item);
    }
}