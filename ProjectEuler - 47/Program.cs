using System.Diagnostics;


internal class EulerProject47
{
    static readonly string question = "The first two consecutive numbers to have two distinct prime factors are:" + "\r\n" +
                                      "   14 = 2 × 7" + "\r\n" +
                                      "   15 = 3 × 5" + "\r\n" + "\r\n" +
                                      "The first three consecutive numbers to have three distinct prime factors are:" + "\r\n" +
                                      "   644 = 2² × 7 × 23" + "\r\n" +
                                      "   645 = 3 × 5 × 43" + "\r\n" +
                                      "   646 = 2 × 17 × 19." + "\r\n" + "\r\n" +
                                      "Find the first four consecutive integers to have four distinct prime" + "\r\n" +
                                      "factors. What is the first of these numbers?";

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

    private static class Solution
    {
        static int count = 0;
        static List<int> Primes = new List<int>{2, 3, 5, 7};

        internal static int Solve()
        {
            int n = 9;

            while (count < 4)
            {
                // find all prime factors for the number, if 4 distinct, increment count, else reset count to 0  
                HashSet<int> factors = new HashSet<int>();

                PopulatePrimesList(n/2);
                FindPrimeFactor(n, ref factors);
                
                if (factors.Count == 4)
                    count++;
                else
                    count = 0;

                n++;
            }
            
            return n-4;
        }

        static void PopulatePrimesList(int limit)
        {
            int start = Primes.Last() + 2;
            for (int i = start; i <= limit; i += 2)
            {
                if (IsPrime(i))
                    Primes.Add(i);
            }
        }

        static void FindPrimeFactor(int n, ref HashSet<int> factors)
        {
            foreach(int prime in Primes)
            {
                if (n % prime == 0)
                {
                    factors.Add(prime);
                    FindPrimeFactor(n / prime, ref factors);
                }
            }
        }

        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int j = 3; j <= Math.Sqrt(n); j += 2)
            {
                if (n % j == 0) return false;
            }

            return true;
        }
    }
}