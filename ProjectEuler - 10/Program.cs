using System.Diagnostics;

internal class EulerProject10
{
    static readonly string question = "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.\r\n\r\n" +
                                      "Find the sum of all the primes below two million.";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int LIMIT = 2000000;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        long sum = 0;
        int count = 0;
        int n = 2;

        while (n < LIMIT)
        {
            if (IsPrime(n))
            {
                sum += (long)n;
                count++;
            }
            n++;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Found " + count + " primes below " + LIMIT + ".");
        Console.WriteLine("Result: " + sum);
        Console.ReadLine();
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
