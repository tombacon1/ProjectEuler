using System.Diagnostics;

internal class EulerProject49
{
    static readonly string question =   "The arithmetic sequence, 1487, 4817, 8147, in which each of the terms\r\n" +  
                                        "increases by 3330, is unusual in two ways: (i) each of the three terms are\r\n" + 
                                        "prime, and, (ii) each of the 4-digit numbers are permutations of one\r\n" + 
                                        "another.\r\n\r\n" + 
                                        "There are no arithmetic sequences made up of three 1-, 2-, or 3-digit\r\n" + 
                                        "primes, exhibiting this property, but there is one other 4-digit\r\n" + 
                                        "increasing sequence.\r\n\r\n" + 
                                        "What 12-digit number do you form by concatenating the three terms in this\r\n" + 
                                        "sequence?";

    static readonly string separator = new string('-', 50) + "\r\n";

        static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        string result = Solution.Solve();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    private static class Solution
    {
        const int LOWER = 1000;
        const int UPPER = 9999;

        internal static string Solve()
        {
            List<int> primes = GetPrimes(LOWER, UPPER);
            Dictionary<int, string> primesOrdered = new Dictionary<int, string>();

            foreach(int i in primes)
            {
                string s = i.ToString();
                primesOrdered.Add(i, String.Concat(s.Order()));
            }

            IEnumerable<IGrouping<string, int>> lookup = primesOrdered.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() >= 3);

            string result = "";
            foreach(IGrouping<string, int> g in lookup)
            {
                List<int> group = g.ToList<int>();
                for(int i = 0; i < group.Count - 2; i++)
                {
                    int diff1 = group[i + 1] - group[i];
                    int diff2 = group[i + 2] - group[i + 1];
                    if(diff1 == diff2)
                    {
                        result = group[i].ToString() + group[i + 1].ToString() + group[i + 2].ToString();
                        break;
                    }
                }
            }

            return result;
        }

        internal static List<int> GetPrimes(int lower, int upper)
        {
            List<int> primes = new List<int>();

            for(int i = lower; i <= upper; i++)
            {
                if(IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        internal static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int j = 3; j <= Math.Sqrt(n); j += 2)
            {
                if (n % j == 0) return false;
            }

            return true;
        }
    }
}