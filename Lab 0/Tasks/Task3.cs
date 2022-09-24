namespace Lab0 
{
    class Task3
    {   
        private List<int> _arr;

        public int? FindMax(int l, int r)
        {
            l -= 1;
            r -= 1;
            if (l< 0) return null;
            if (r >= _arr.Count() ) return null;
            return _arr.Skip(l).Take(r-l+1).Max();
        }
        public void ReadData(string name)
        {
            string path = @$"{name}";
            StreamReader sr = new StreamReader(path);
            _arr = new List<int>();
            _arr = sr.ReadToEnd().Split("\n").Select(x => Convert.ToInt32(x)).ToList();
            Console.WriteLine($"Записан массив размера {_arr.Count()}");
        }
    }
}