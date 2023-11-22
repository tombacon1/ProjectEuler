using System.Diagnostics;

internal class EulerProject7
{
    static readonly string question = "By listing the first six prime numbers:\r\n" +
                                      "2, 3, 5, 7, 11 and 13, we can see that the 6th prime is 13.\r\n\r\n" +
                                      "What is the 10001st prime number?";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int NUM_PRIMES = 10001;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int count = 1;
        int result = 1;

        while(count < NUM_PRIMES)
        {
            result += 2;
            if (IsPrime(result))
                count++;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
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
}
