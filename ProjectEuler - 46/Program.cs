using System.Diagnostics;

internal class EulerProject46
{
    static readonly string question = "It was proposed by Christian Goldbach that every odd composite number \r\n" + 
                                      "can be written as the sum of a prime and twice a square.\r\n\r\n" +
                                      "It turns out that the conjecture was false.\r\n\r\n" +
                                      " 9 = 7 + 2 x 1^2" + "\r\n" +
                                      "15 = 7 + 2 x 2^2" + "\r\n" +
                                      "21 = 3 + 2 x 3^2" + "\r\n" +
                                      "25 = 7 + 2 x 3^2" + "\r\n" +
                                      "27 = 19 + 2 x 2^2" + "\r\n" +
                                      "33 = 31 + 2 x 1^2" + "\r\n\r\n" +
                                      "What is the smallest odd composite that cannot be written as the sum \r\n" +
                                      "of a prime and twice a square?";
    static readonly string separator = new string('-', 50) + "\r\n";

    static int _n = 1;
    static int _p = 2;
    static List<int> Primes = new List<int>();

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
        internal static int Solve()
        {
            while(true)
            {
                
                _n = GetNextOddComposite();
                while(_p < _n)
                {
                    Primes.Add(_p);
                    _p = GetNextPrime();
                }

                bool match = true;

                foreach(int prime in Primes){
                    int candidate = prime + 2;
                    for (int i = 2; candidate <= _n; i++)
                    {
                        if (candidate == _n)
                        {
                            match = false;
                            break;
                        }

                        candidate = prime + 2 * i * i;
                    }
                }

                if (match)
                    return _n;
            }
        }

        internal static int GetNextOddComposite()
        {
            int next = _n + 2;
            while (IsPrime(next) || next % 2 == 0)
                next += 2;
            return next;
        }

        internal static int GetNextPrime()
        {
            if (_p < 2) return 2;
            if (_p == 2) return 3;

            int next = _p + 1;
            while (!IsPrime(next))
                next++;

            return next;
        }

        internal static bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
    }
}
