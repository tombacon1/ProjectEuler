using System.Diagnostics;

class EulerProject3
{
    static readonly string question = "The prime factors of 13195 are 5, 7, 13 and 29.\r\n\r\n" + 
                             "What is the largest prime factor of the number 600851475143 ?\r\n";
    static readonly string separator = new string('-', 50) + "\r\n";

    static long refNum = 600851475143;
    static long result;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        result = GetLargestPrimeFactor(refNum);

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        
    }

    private static long GetLargestPrimeFactor(long refNum)
    {
        long result = 0;
        int i = 2;
        while(i < refNum / 2)
        {
            if (refNum % i == 0)
            {
                result = refNum / i;
                if (IsPrime(result))
                    break;
            }
            result = 0;
            i++;
        }
        return result;
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