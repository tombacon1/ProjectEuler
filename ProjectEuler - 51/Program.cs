using System.Diagnostics;

internal class EulerProject51
{
    static readonly string question =   "By replacing the 1st digit of the 2-digit number *3, it turns out that\r\n" + 
                                        "six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all\r\n" + 
                                        "prime.\r\n" +
                                        "By replacing the 3rd and 4th digits of 56**3 with the same digit, this\r\n" +
                                        "5-digit number is the first example having seven primes among the ten\r\n" +
                                        "generated numbers, yielding the family: 56003, 56113, 56333, 56443, 56663,\r\n" +
                                        "56773, and 56993. Consequently 56003, being the first member of this\r\n" +
                                        "family, is the smallest prime with this property.\r\n\r\n" +
                                        "Find the smallest prime which, by replacing part of the number (not\r\n" +
                                        "necessarily adjacent digits) with the same digit, is part of an eight\r\n" +
                                        "prime value family.\r\n";

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
        private static int _p;

        public static int Solve()
        {
            int replacementDigit = 0;
            int response = ReplaceDigit(123456789, 5, 9);

            
            return 0;
        }

        /// <summary>
        /// Replace a specific digit in an integer with a new digit and return the new integer.
        /// </summary>
        /// <param name="number">Input integer</param>
        /// <param name="indexToReplace">One-based index of the digit to replace</param>
        /// <param name="replacementDigit">The digit to replace with</param>
        /// <returns>The new integer with the specified digit replaced</returns>
        private static int ReplaceDigit(int number, int indexToReplace, int replacementDigit)
        {
            int len = (int)Math.Log10(number) + 1;
            Stack<int> digits = new Stack<int>();
            
            for(int i = 0; i < len; i++)
            {
                if(i == len - indexToReplace)
                    digits.Push(replacementDigit);
                else
                    digits.Push(number % 10);

                number /= 10;
            }

            int newNumber = DigitsToInt(digits);
            return newNumber;
        }

        private static int DigitsToInt(Stack<int> digits)
        {
            int n = 0;

            while(digits.Count > 0)
            {
                n *= 10;
                n += digits.Pop();
            }
            return n;
        }

        private static int GetNextPrime()
        {
            if (_p < 2) return 2;
            if (_p == 2) return 3;

            int next = _p + 1;
            while (!IsPrime(next))
                next++;

            return next;
        }

        private static bool IsPrime(int n)
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