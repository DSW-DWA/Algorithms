namespace Lab0 
{
    class Task2
    {
        public int n { get; set; }
        public int AllDivisors() 
        {
            int sum = 2;
            for (int i = 2; i < Math.Sqrt(n)+1; i++)
            {
                if (n%i == 0) sum += 2;
            }
            return sum;
        }
        public int PrimeDivisors()
        {
            int sum = 1;
            if (IsPrime(n)) sum += 1;
            for (int i = 2; i < Math.Sqrt(n)+1; i++)
            {
                if (n%i == 0)
                {
                    if ( IsPrime(i)) sum+= 1;
                    if ( IsPrime(n/i)) sum+= 1; 
                }
            }
            return sum;
        }
        private bool IsPrime(int a)
        {
            if ( a == 1 ) return true;
            for (int i = 1; i <= Math.Ceiling(Math.Sqrt(a)); i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        } 
    }
}