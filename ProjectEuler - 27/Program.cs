using System.Diagnostics;

internal class EulerProject27
{
    static readonly string question = "   Euler discovered the remarkable quadratic formula:\r\n\r\n" +
        "                                  n² + n + 41\r\n\r\n" +
        "    It turns out that the formula will produce 40 primes for the consecutive\r\n" +
        "   values n = 0 to 39. However, when n = 40, 40^2 + 40 + 41 = 40(40 + 1) + 41\r\n" +
        "   is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly\r\n" +
        "   divisible by 41.\r\n\r\n" +
        "   The incredible formula  n² − 79n + 1601 was discovered, which produces 80\r\n" +
        "   primes for the consecutive values n = 0 to 79. The product of the\r\n" +
        "   coefficients, −79 and 1601, is −126479.\r\n\r\n" +
        "   Considering quadratics of the form:\r\n\r\n" +
        "     n² + an + b, where |a| < 1000 and |b| <= 1000\r\n\r\n" +
        "     where |n| is the modulus/absolute value of n\r\n" +
        "     e.g. |11| = 11 and |−4| = 4\r\n\r\n" +
        "   Find the product of the coefficients, a and b, for the quadratic\r\n" +
        "   expression that produces the maximum number of primes for consecutive\r\n" +
        "   values of n, starting with n = 0.";
    static readonly string separator = new string('-', 50) + "\r\n";
    static readonly string tab = new string(' ', 4);

    public struct Result
    {
        public int a { get; set; }
        public int b { get; set; }
        public int count { get; set; }
    }

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        List<Result> results = new List<Result>();
        List<int> primesToOneThousand = new List<int>();

        for (int i = 0; i <= 1000; i++)
        {
            if (IsPrime(i))
                primesToOneThousand.Add(i);
        }

        for (int a = -999; a < 1000; a++)
            foreach (int b in primesToOneThousand)
            {
                results.Add(new Result { a = a, b = b, count = CountQuadraticPrimes(a, b) });
            }

        Result result = results.MaxBy(r => r.count);

        int product = result.a * result.b;

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: \r\n" + tab + "a: " + result.a + "\r\n" + tab + "b: " + result.b + "\r\n" +  tab + "count: " + result.count + "\r\n" + tab + "product: " + product);
        Console.ReadLine();
    }

    static long QuadraticEquation(int x, int a, int b)
    {
        return x * x + x * a + b;
    }

    static int CountQuadraticPrimes(int a, int b)
    {
        int n = 0;
        while (true)
        {
            long res = QuadraticEquation(n, a, b);
            if (!IsPrime(res))
                return n;
            n++;
        }
    }

    static bool IsPrime(long n)
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
}
