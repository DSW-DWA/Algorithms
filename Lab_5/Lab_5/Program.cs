namespace Lab_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Search.InterpolationSearch(5000,1000);
            Search.InterpolationSearch(5000,2000);
            Search.InterpolationSearch(5000,4000);
            Search.InterpolationSearch(5000,8000);
            Search.BinarySearch(5000,16000);
        }
    }
}