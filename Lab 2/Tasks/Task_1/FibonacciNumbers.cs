namespace Lab2
{
    public class FibonacciNumbers
    {
        private double[] _numbersForDynamicDown;
        public FibonacciNumbers(int n)
        {
            _numbersForDynamicDown = new double[n+1];
        }
        public double Bine(int n)
        {
            double a = (1 + Math.Sqrt(5)) / 2;
            double b = (1 - Math.Sqrt(5)) / 2;
            return (Math.Pow(a, n) - Math.Pow(b, n)) / Math.Sqrt(5);
        }
        public double DynamicUp(int n)
        {
            double[] values = new double[n+1];
            values[0] = 1;
            values[1] = 1;
            for (int i = 2; i <=n; i++ )
            {
                values[i] = values[i-1] + values[i-2];
            }
            return values[n];
        }
        public double DynamicDown(int n)
        {
            if (_numbersForDynamicDown[n] == 0)
            {
                if (n == 0) 
                {
                    _numbersForDynamicDown[n] = 0;
                }
                else if (n == 1)
                {
                    _numbersForDynamicDown[n] = 1;
                }
                else 
                {
                    _numbersForDynamicDown[n] = DynamicDown(n-1) + DynamicDown(n-2);
                }
            }
            return _numbersForDynamicDown[n];
        }
        public double DivideAndConquer(int n)
        {
            if (n == 0) 
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else 
            {
                return DivideAndConquer(n-1) + DivideAndConquer(n-2);
            }
        }
        public double Iterationnal(int n)
        {
            if (n <= 2) return 1;
            var prev1 = 1;
            var prev2 = 1;
            var now = prev1 + prev2;
            for (int i = 4; i <= n; i++)
            {
                prev2 = now;
                prev1 = prev2;
                now = prev2 + prev1;
            }
            return now;
        }
    }
}