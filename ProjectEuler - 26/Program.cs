using System.Diagnostics;

internal class EulerProject26
{
    static readonly string question = "A unit fraction contains 1 in the numerator.\r\n" + 
        "The decimal representation of the unit fractions with denominators 2 to 10 are given:\r\n\r\n" +
        "1/2 = 0.5\r\n1/3 =0.(3)\r\n1/4 =0.25\r\n1/5 = 0.2\r\n1/6 = 0.1(6)\r\n1/7 = 0.(142857)\r\n1/8 = 0.125\r\n1/9 = 0.(1)\r\n1/10 = 0.1\r\n\r\n" +
        "Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.\r\n\r\n" + 
        "Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int LIMIT = 1000;
    const string TAB = "    ";

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        Dictionary<int, int> results = new Dictionary<int, int>();

        for (int i = 3; i < LIMIT; i++)
        {
            int len = FindRecurringCycle(i);
            results.Add(i, len);
        }

        KeyValuePair<int, int> maxCycle = results.MaxBy(r => r.Value);

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: \r\n" + TAB + "Denominator: " + maxCycle.Key + "\r\n" + TAB + "Cycle length: " + maxCycle.Value);
        Console.ReadLine();
    }

    private static int FindRecurringCycle(int d)
    {
        int[] seen = new int[d];
        seen[1] = 1; 
        int i = 2;
        int n = 1;
        int rem = 0;

        while (true)
        {
            n *= 10;
            rem = n % d;
            if (rem == 0)
                return 0;
            if (seen[rem] != 0)
                return i - seen[rem];
            seen[rem] = i;
            i++;
            n = rem;
        }
    }
}
