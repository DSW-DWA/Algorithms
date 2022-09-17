namespace Lab0 
{
    class Task1
    {
        public int n { get; set; }
        public List<Tuple<int,int>> list { get; set;}

        public void Add(Tuple<int,int> tuple) 
        {
            list.Add(new Tuple<int, int>(tuple.Item1, tuple.Item2));
            list.OrderBy(x => x.Item1 + x.Item2);
        }
    }
}