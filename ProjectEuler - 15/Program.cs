using System.Diagnostics;

internal class EulerProject15
{
    static readonly string question = "Starting in the top left corner of a 2 x 2 grid, and only being able to move to the right and down,\r\n" +
                                      "there are exactly 6 routes to the bottom right corner.\r\n\r\n" +
                                      "How many such routes are there through a 20 x 20 grid?";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int GRID_SIZE = 20;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        long numPaths = CalculateLatticePaths();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + numPaths);
        Console.ReadLine();
    }

    private static long CalculateLatticePaths()
    {
        return BinomialCoefficient(GRID_SIZE + GRID_SIZE, 20);
    }

    private static long BinomialCoefficient(int n, int k)
    {
        if (k > n) { return 0; }
        if (n == k) { return 1; } // only one way to chose when n == k
        if (k > n - k) { k = n - k; } // Everything is symmetric around n-k, so it is quicker to iterate over a smaller k than a larger one.
        
        long c = 1;
        
        for (long i = 1; i <= k; i++)
        {
            c *= n--;
            c /= i;
        }
        
        return c;
    }
}