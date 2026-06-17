using System.Diagnostics;

internal class EulerProject50
{
    static readonly string question =   "The prime 41, can be written as the sum of six consecutive primes:\r\n" + 
                                        "41 = 2 + 3 + 5 + 7 + 11 + 13\r\n" + 
                                        "This is the longest sum of consecutive primes that adds to a prime below\r\n" + 
                                        "one-hundred.\r\n\r\n" + 
                                        "The longest sum of consecutive primes below one-thousand that adds to a\r\n" + 
                                        "prime, contains 21 terms, and is equal to 953.\r\n" + 
                                        "Which prime, below one-million, can be written as the sum of the most\r\n" + 
                                        "consecutive primes?";

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
        const int ONE_MILLION = 1000000;

        internal static int Solve()
        {
            int[] primes = GetPrimes(2, ONE_MILLION);
            
            int longestSum = 0;
            int largestPrime = 0;
            
            for(int i = 0; i < primes.Length; i++)
            {
                int sum = 0;
                int j = i;
                while(sum < ONE_MILLION && j < primes.Length)
                {
                    sum += primes[j];
                    if(j - i + 1 > longestSum && IsPrime(sum))
                    {
                        longestSum = j - i + 1;
                        largestPrime = sum;
                    }

                    j++;
                }
            }

            return largestPrime;
        }

        internal static int[] GetPrimes(int lower, int upper)
        {
            List<int> primes = new List<int>();

            for(int i = lower; i <= upper; i++)
            {
                if(IsPrime(i))
                    primes.Add(i);
            }

            return primes.ToArray<int>();
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