using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;

internal class EulerProject34
{
    static readonly string question = "    145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.\r\n\r\n" +
        "    Find the sum of all numbers which are equal to the sum of the factorial of their digits.\r\n\r\n" + 
        "    Note: As 1! = 1 and 2! = 2 are not sums they are not included.";
    static readonly string separator = new string('-', 50) + "\r\n";

    const string ARG_OUT_OF_RANGE_MSG = "Integer parameter n must be a positive integer greater than or equal to 0.";

    static readonly int UPPER_BOUND = Factorial(9) * 7;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();
        
        int n = 10;
        int sum = 0;

        while (n <= UPPER_BOUND)
        {
            Stack<int> digits = GetDigits(n);

            if (n.Equals(SumOfDigitFactorials(digits)))
                sum += n;

            n++;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + sum);
        Console.ReadLine();
    }

    private static int SumOfDigitFactorials(Stack<int> digits)
    {
        int sum = 0;
        foreach (int i in digits)
            sum += Factorial(i);

        return sum;
    }

    private static Stack<int> GetDigits(int n)
    {
        var digits = new Stack<int>();

        while (n > 0)
        {
            digits.Push(n % 10);
            n /= 10;
        }
        return digits;
    }

    private static int Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), ARG_OUT_OF_RANGE_MSG);

        if (n == 0)
            return 1;

        return n * Factorial(n - 1);
    }
}
