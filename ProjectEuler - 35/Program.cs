using System.Diagnostics;

internal class EulerProject35
{
    static readonly string question = "    The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.\r\n\r\n" + 
                                      "    There are thirteen such primes below 100: 2,3,5,7,11,13,17,31,37,71,73,79, and 97.\r\n\r\n" + 
                                      "    How many circular primes are there below one million?";
    static readonly string separator = new string('-', 50) + "\r\n";


    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int result = Solution.Solve();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    static class Solution 
    {
        const int MAX_RANGE = 1000000;

        internal static int Solve()
        {
            List<int> circularPrimes = new List<int> { 2, 3, 5, 7 };
            List<int> invalidDigits = new List<int> { 2, 4, 5, 6, 8, 0 };
            bool allPrime;

            for (int n = 10; n < MAX_RANGE; n++)
            {
                if (IsPrime(n))
                {
                    allPrime = true;
                    Queue<int> digits = GetDigits(n);
                    
                    if (digits.ToList().Any(x => invalidDigits.Any(y => y == x)))
                        continue;
                    
                    for (int i = 1; i <= digits.Count; i++)
                    {
                        int j = RotateDigits(digits);
                        if (!IsPrime(j))
                        {
                            allPrime = false;
                            break;
                        }
                    }
                    if (allPrime)
                        circularPrimes.Add(n);
                }
            }
            return circularPrimes.Count;
        }

        private static int RotateDigits(Queue<int> digits)
        {
            int front = digits.Dequeue();
            digits.Enqueue(front);
            return DigitsToInt(digits.ToList());
        }

        static bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
                return true;

            if (n <= 1 || n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        private static Queue<int> GetDigits(int n)
        {
            var digits = new Queue<int>();

            while (n > 0)
            {
                digits.Enqueue(n % 10);
                n /= 10;
            }

            return new Queue<int>(digits.Reverse());
        }

        private static int DigitsToInt(List<int> list)
        {
            return int.Parse(string.Join(",", list).Replace(",", ""));
        }
    }

}
