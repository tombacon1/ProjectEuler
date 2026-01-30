using System.Diagnostics;

internal class EulerProject41
{
    static readonly string question = "We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once.\r\n" + 
                                      "For example, 2143 is a 4-digit pandigital and is also prime.\r\n\r\nWhat is the largest n-digit pandigital prime that exists?";
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
        internal static int Solve()
        {
            int solution = 0;
            List<int> permutations = new List<int>();
            for (int length = 9; length >= 1; length--)
            {
                int[] digits = GetPandigitalDigits(length);

                foreach (int[] a in Permute(length, digits))
                {
                    int i = IntArrayToInt(a);

                    if (IsPrime(i))
                        solution = Math.Max(solution, i);
                }
                if (solution > 0)
                    break;
            }

            return solution;
        }

        private static int IntArrayToInt(int[] a)
        {
            int result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                result += a[i] * Convert.ToInt32(Math.Pow(10, a.Length - i - 1));
            }
            
            return result;
        }


        private static int[] GetPandigitalDigits(int length)
        {
            int[] digits = new int[length];

            for (int i = 0; i < length; i++)
                digits[i] = length - i;

            return digits;
        }

        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
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

