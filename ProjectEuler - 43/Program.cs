using System.Diagnostics;
using System.Numerics;

internal class EulerProject43
{
    static readonly string question = "The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the \r\n" + 
                                      "digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.\r\n\r\n" + 
                                      "Let d_1 be the 1st digit, d_2 be the 2nd digit, and so on. In this way, we note the following:\r\n\r\n" +
                                      " d_2 ⌢ d_3 ⌢ d_4  = 406 is divisible by 2\r\n" +
                                      " d_3 ⌢ d_4 ⌢ d_5  = 063 is divisible by 3\r\n" + 
                                      " d_4 ⌢ d_5 ⌢ d_6  = 635 is divisible by 5\r\n" + 
                                      " d_5 ⌢ d_6 ⌢ d_7  = 357 is divisible by 7\r\n" + 
                                      " d_6 ⌢ d_7 ⌢ d_8  = 572 is divisible by 11\r\n" + 
                                      " d_7 ⌢ d_8 ⌢ d_9  = 728 is divisible by 13\r\n" + 
                                      " d_8 ⌢ d_9 ⌢ d_10 = 289 is divisible by 17\r\n\r\n" + 
                                      "Find the sum of all 0 to 9 pandigital numbers with this property.";
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
        static int[] divisors = new int[] { 2, 3, 5, 7, 11, 13, 17 };

        internal static BigInteger Solve()
        {
            BigInteger solution = 0;
            int length = 10;

            int[] digits = GetPandigitalDigits(length);

            foreach (int[] a in Permute(length, digits))
            {
                if (a[0] == 0)
                    continue;

                bool dividesByPrime = true;

                for (int j = length - 1; j >= 3; j--)
                {
                    int[] triplet = (a.Take(new Range(j - 2, j + 1))).ToArray();
                    BigInteger i = IntArrayToBigInt(triplet);

                    if (i % divisors[j - 3] != 0)
                    {
                        dividesByPrime = false;
                        break;
                    }
                }
                if (dividesByPrime)
                    solution += IntArrayToBigInt(digits);
            }
            
            return solution;
        }

        private static BigInteger IntArrayToBigInt(int[] a)
        {
            BigInteger result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                result += (BigInteger)a[i] * BigInteger.Pow(10, a.Length - i - 1);
            }

            return result;
        }


        private static int[] GetPandigitalDigits(int length)
        {
            int[] digits = new int[length];

            for (int i = 0; i < length; i++)
                digits[i] = i;

            return digits;
        }

        static IEnumerable<int[]> Permute(int k, int[] digits)
        {
            if (k == 1)
            {
                yield return (int[])digits.Clone();
                yield break;
            }

            for (int i = 0; i < k; i++)
            {
                foreach (var p in Permute(k - 1, digits))
                    yield return p;

                if (k % 2 == 0)
                    Swap(ref digits, i, k - 1);
                else
                    Swap(ref digits, 0, k - 1);
            }
        }

        private static void Swap(ref int[] digits, int i, int j) => (digits[i], digits[j]) = (digits[j], digits[i]);
    }
}

