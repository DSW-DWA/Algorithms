namespace Lab2
{
    public class ItemOfBackpack
    {
        public string Name { get; }
        public int Weight { get; }
        public int Price { get; }
        public ItemOfBackpack(int weight, int price, string name)
        {
            Weight = weight;
            Price = price;
            Name = name;
        }
    }
}