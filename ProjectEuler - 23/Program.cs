using System.Diagnostics;
using System.Net;

internal class EulerProject23
{
    static readonly string question = "A perfect number is a number for which the sum of its proper divisors is exactly equal to the number.\r\n\r\n" +  
        "For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28,\r\n" + 
        "which means that 28 is a perfect number.\r\n\r\n" +
        "A number n is called deficient if the sum of its proper divisors is less than n and it\r\n" +
        "is called abundant if this sum exceeds n.\r\n\r\n" +
        "As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be\r\n" +  
        "written as the sum of two abundant numbers is 24.\r\n\r\n" + 
        "By mathematical analysis, it can be shown that all integers greater than 28123\r\n" + 
        "can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced\r\n" + 
        "any further by analysis even though it is known that the greatest number that cannot be expressed\r\n" + 
        "as the sum of two abundant numbers is less than this limit.\r\n\r\n" + 
        "Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int LIMIT = 28123;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        List<int> abundantNumbersBelowLimit = GetAbundantNumbers(LIMIT);
        List<int> sumsOfAllAbundantPairs = GetSumsForAllPairsOfNumbers(abundantNumbersBelowLimit);

        int result = 0;
        for (int i = 1; i <= LIMIT; i++)
        {
            if (!sumsOfAllAbundantPairs.Contains(i))
                result += i;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    private static List<int> GetSumsForAllPairsOfNumbers(List<int> numbers)
    {
        List<int> sums = new List<int>();
        int size = numbers.Count;
        for (int i = 0; i < size; i++)
            for (int j = i; j < size; j++)
            {
                sums.Add(numbers[i] + numbers[j]);
            }

        return sums;
    }

    private static List<int> GetAbundantNumbers(int max)
    {
        List<int> abundantNumbers = new List<int>();

        for (int i = 0; i < max; i++)
        {
            if(IsAbundant(i))
                abundantNumbers.Add(i);
        }

        return abundantNumbers; 
    }

    static bool IsAbundant(int n)
    {
        List<int> divisors = GetProperDivisors(n);
        int sum = 0;
        foreach(int divisor in divisors)
            sum += divisor;

        return sum > n;
    }

    static List<int> GetProperDivisors(int n)
    {
        List<int> divisors = new List<int>();

        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
                if (i > 1 && i * i < n)
                    divisors.Add(n / i);
            }
        }

        divisors.Sort();

        return divisors;
    }
}
