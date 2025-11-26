using System.Diagnostics;

internal class EulerProject37
{
    static readonly string question = "    The number 3797 has an interesting property. Being prime itself, it is possible to continuously\r\n" + 
                                      "    remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7.\r\n" + 
                                      "    Similarly we can work from right to left: 3797, 379, 37, and 3.\r\n\r\n" + 
                                      "    Find the sum of the only eleven primes that are both truncatable from left to right and right to left.\r\n\r\n" + 
                                      "    NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.";
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
    internal static class Solution
    {
        internal static int Solve()
        {
            int sum = 0;
            int count = 0;
            int i = 11;

            while(count < 11)
            {
                if (IsPrime(i))
                    if (IsTruncatablePrime(i))
                    {
                        sum += i;
                        count++;
                    }
                i++;
            }

            return sum;
        }

        private static bool IsTruncatablePrime(int i)
        {
            int ltrTruncation = TruncateIntLtR(i);

            while (ltrTruncation > 0)
            {
                if (!IsPrime(ltrTruncation))
                    return false;

                ltrTruncation = TruncateIntLtR(ltrTruncation);
            }

            int rtlTruncation = TruncateIntRtL(i);

            while (rtlTruncation > 0)
            {
                if (!IsPrime(rtlTruncation))
                    return false;

                rtlTruncation = TruncateIntRtL(rtlTruncation);
            }
            return true;
        }

        private static int TruncateIntLtR(int n) => n /= 10;

        private static int TruncateIntRtL(int n)
        {
            int multiplier = 1;
            int leftDigit = n;

            while (leftDigit > 10)
            {
                leftDigit /= 10;
                multiplier *= 10;
            }

            return n - (leftDigit * multiplier);
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
}