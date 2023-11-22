using System.Diagnostics;

internal class EulerProject9
{
    static readonly string question = "A Pythagorean triplet is a set of three natural numbers, a < b < c,\r\n" +
                                      "for which, a^2 + b^2 = c^2. For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.\r\n\r\n" +
                                      "There exists exactly one Pythagorean triplet for which a + b + c = 1000.\r\n\r\n" + 
                                      "Find the product abc.";
    static readonly string separator = new string('-', 50) + "\r\n";
    const int SUMMED_VALUE = 1000;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int m = 2;
        int sum = 0;
        int limit = (int) Math.Sqrt(SUMMED_VALUE);
        int[] triple = new int[3];
        int result = 0;

        while(sum != SUMMED_VALUE && m < limit)
        {
            for(int n = 1; n < m; n++)
            {
                triple = GetPythagoranTriple(m, n);
                sum = triple[0] + triple[1] + triple[2];
                if (sum == SUMMED_VALUE)
                {
                    result = triple[0] * triple[1] * triple[2];
                    break;
                }
            }
            m++;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Triple: " + triple[0] + "," + triple[1] + "," + triple[2]);
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    /// <summary>
    /// Euclid's formula:
    /// where m > n > 0
    /// a = m^2 - n^2, b = 2mn, c = m^2 + n^2
    /// </summary>
    /// <param integer greater than n="m"></param>
    /// <param integer greater than zero="n"></param>
    static int[] GetPythagoranTriple(int m, int n)
    {
        int a, b, c;

        a = m * m - n * n;
        b = 2 * m * n;
        c = m * m + n * n;

        return new int[3] { a, b, c };
    }
}
