using System.Diagnostics;

internal class EulerProject38
{
    static readonly string question = "    Take the number 192 and multiply it by each of 1, 2, and 3:\r\n\r\n" + 
                                      "    192×1=192\r\n    192×2=384\r\n    192×3=576\r\n \r\n" + 
                                      "    By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated \r\n" + 
                                      "    product of 192 and (1,2,3).\r\n\r\n" + 
                                      "    The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, \r\n" + 
                                      "    which is the concatenated product of 9 and (1,2,3,4,5).\r\n\r\n" + 
                                      "    What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer \r\n" + 
                                      "    with (1,2,…,𝑛) where 𝑛 >1?";
    static readonly string separator = new string('-', 50) + "\r\n";

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        uint result = Solution.Solve();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    static class Solution
    {
        const int UPPER_LIMIT = 10000;

        internal static uint Solve()
        {
            uint largestPandigital = 0;

            for(int i = 1; i < UPPER_LIMIT; i++)
            {
                int multiplier = 1;
                string concatenation = String.Empty;
                while(concatenation.Length < 9)
                {
                    concatenation += (i * multiplier).ToString();
                    multiplier++;
                }
                
                if (concatenation.Length > 9)
                    continue;

                uint candidate = uint.Parse(concatenation);
                
                if (IsPanDigital(candidate))
                    largestPandigital = Math.Max(largestPandigital, candidate);
            }

            return largestPandigital;
        }
    }

    static bool IsPanDigital(uint n)
    {
        const string SORTED_DIGITS = "123456789";

        if (n < Math.Pow(10, 8))
            return false;

        string digits = n.ToString();

        char[] digitsCharArray = digits.ToCharArray();
        Array.Sort(digitsCharArray);

        return new String(digitsCharArray).Equals(SORTED_DIGITS);
    }
}

