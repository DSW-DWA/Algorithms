namespace Lab2
{
    public class Turtle
    {
        private int[][] _field;
        private int n;
        private int m;
        public Turtle(string path)
        {
            try
            {
                var data = File.ReadAllLines(path).Select(x => x.Split(" ").ToList()).ToList();
                _field = new int[Convert.ToInt32(data[0][0])][];
                n = Convert.ToInt32(data[0][0]);
                m = Convert.ToInt32(data[0][1]);
                var input = data.Skip(1);
                _field = input.Select(x => x.Select(xx => Convert.ToInt32(xx)).ToArray()).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public void Solving()
        {
            for (int i =1 ; i < n; i++)
            {
                _field[i][0] += _field[i-1][0];
            }
            for (int i =1 ; i < m; i++)
            {
                _field[0][i] += _field[0][i-1];
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    _field[i][j] = Math.Max(_field[i-1][j], _field[i][j-1]);
                }
            }
            Console.WriteLine($"Max score is {_field[n-1][m-1]}");
        }
    }
}