using System.Diagnostics;

internal class EulerProject21
{
    static readonly string question = "Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).\r\n\r\n" + 
        "If d(a) = b and d(b) = a, where a != b, then a and b are an amicable pair\r\n"  + 
        "and each of a and b are called amicable numbers.\r\n\r\n" + 
        "For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110;\r\n" + 
        "therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.\r\n\r\n" + 
        "Evaluate the sum of all the amicable numbers under 10000.";
    static readonly string separator = new string('-', 50) + "\r\n";

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int sum = 0;

        for (int a = 1; a < 10000; a++)
        {
            int b, n;
            
            List<int> divisors = GetProperDivisors(a);
            b = SumList(divisors);

            if (b <= a) continue;
            
            divisors = GetProperDivisors(b);
            n = SumList(divisors);

            if (n == a) sum += a + b;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + sum);
        Console.ReadLine();
    }

    private static int SumList(List<int> divisors)
    {
        int sum = 0;
        foreach (int divisor in divisors)
            sum += divisor;
        return sum;
    }

    static List<int> GetProperDivisors(int n)
    {
        List<int> divisors = new List<int>();

        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
                if(i > 1 && i * i < n)
                    divisors.Add(n / i);
            }
        }
        
        divisors.Sort();
        
        return divisors;
    }
}
