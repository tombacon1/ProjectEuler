using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

internal class EulerProject31
{
    static readonly string question = "   In England the currency is made up of pound, £, and pence, p, and there\r\n" + 
        "  are eight coins in general circulation:\r\n\r\n" + 
        "    1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).\r\n\r\n" + 
        "  It is possible to make £2 in the following way:\r\n\r\n" + 
        "    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p\r\n\r\n" + 
        "  How many different ways can £2 be made using any number of coins?";
    static readonly string separator = new string('-', 50) + "\r\n";

    static readonly int target = 200;
    static readonly int[] values = { 1, 2, 5, 10, 20, 50, 100, 200 };

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int result = CountCombinations(target);

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    private static int CountCombinations(int target)
    {
        int count = 0;
        CountCombinationsRecursive(ref count, 0, target);
        return count;
    }

    private static void CountCombinationsRecursive(ref int count, int prevValueIndex, int target)
    {
        // overshot target
        if (target < 0)
            return;

        // hit target value
        if (target == 0)
        {
            count++;
            return;
        }

        for (int i = prevValueIndex; i < values.Length; i++)
            CountCombinationsRecursive(ref count, i, target - values[i]);
    }
}
