namespace Lab0 
{
    class Task3
    {
        public int n 
        {
            get { return n;}
            set { arr = new int[value]; n = value;}
        }
        
        private int[] arr;

        public int? FindMax(int l, int r)
        {
            if (l< 0) return null;
            if (r >= n ) return null;
            return arr.Skip(l).Take(r-l+1).Max();
        }
        public void ReadData(string name)
        {
            string path = @$"{name}";
            StreamReader sr = new StreamReader(path);
            // var m = sr.ReadToEnd();
            // foreach (var item in m)
            // {
            //     Console.Write(item + " ");
            // }
        }
    }
}