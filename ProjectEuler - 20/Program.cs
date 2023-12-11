using System.Diagnostics;
using System.Numerics;

internal class EulerProject20
{
    static readonly string question = "n! means n * (n - 1) * ... * 3 * 2 * 1.\r\n\r\n" + 
        "For example, 10! = 10 * 9 * ... * 3 * 2 * 1 = 3628800,\r\n" +
        "and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.\r\n\r\n" + 
        "Find the sum of the digits in the number 100!.";
    static readonly string separator = new string('-', 50) + "\r\n";


    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        BigInteger oneHundredFactorial = Factorial(100);
        int[] digits = GetNumericStringAsIntArray(oneHundredFactorial.ToString());

        int sum = 0;
        foreach(int digit in digits)
            sum += digit;

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + sum);
        Console.ReadLine();
    }

    private static int[] GetNumericStringAsIntArray(string number)
    {
        List<int> digits = new List<int>();
        foreach(char c in number)
            digits.Add(Convert.ToInt32(char.GetNumericValue(c)));

        return digits.ToArray();
    }

    private static BigInteger Factorial(int n)
    {
        BigInteger result = BigInteger.One;
        for (int i = n; i > 1; i--)
            result *= i;

        return result;
    }
}
