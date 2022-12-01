namespace Lab_3_fix.Tasks.Task_5;

public class PriorityQueueInsert
{
    private List<Item> _items;

    public PriorityQueueInsert()
    {
        _items = new List<Item>();
    }

    public void Insert(Item item)
    {
        var ind = _items.FirstOrDefault(x => x.Value < item.Value);
        if (ind == null)
        {
            _items.Add(item);
        }
        else
        {
            _items.Insert(Convert.ToInt32(ind), item);
        }
    }

    public void Delete()
    {
        if (_items.Count == 0)
        {
            throw new Exception("Не возможно удалить из пустой очереди");
        }
        var first = _items.First();
        _items.Remove(first);
    }
}