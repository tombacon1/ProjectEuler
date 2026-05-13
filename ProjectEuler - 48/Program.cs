using System.Diagnostics;
using System.Numerics;

internal class EulerProject48
{
    static readonly string question = "The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.\r\n" + 
                                      "Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.";

    static readonly string separator = new string('-', 50) + "\r\n";

        static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        BigInteger result = Solution.Solve();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    private static class Solution
    {

        internal static BigInteger Solve()
        {
            BigInteger sum = 0;

            for(int i = 1; i <= 1000; i++)
            {
                sum += BigInteger.Pow(i, i);
            }
            
            string sumAsString = sum.ToString();

            return BigInteger.Parse(sumAsString.Substring(sumAsString.Length - 10));
        }
    }
}