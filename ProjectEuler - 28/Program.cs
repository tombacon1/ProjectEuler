using System.Diagnostics;

internal class EulerProject28
{
    static readonly string question = "   Starting with the number 1 and moving to the right in a clockwise\r\n" +
        "   direction a 5 by 5 spiral is formed as follows:\r\n\r\n" +
        "                                 21 22 23 24 25\r\n" +
        "                                 20  7  8  9 10\r\n" +
        "                                 19  6  1  2 11\r\n" +
        "                                 18  5  4  3 12\r\n" +
        "                                 17 16 15 14 13\r\n\r\n" +
        "   It can be verified that the sum of the numbers on the diagonals is 101.\r\n\r\n" +
        "   What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral\r\n" +
        "   formed in the same way?";
    static readonly string separator = new string('-', 50) + "\r\n";

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int sum = SumSpiralDiagonals(1001);

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + sum);
        Console.ReadLine();
    }

    private static int SumSpiralDiagonals(int size)
    {
        int gap = 2;
        int sum = 1;
        int index = 1;
        while (gap <= size - 1)
        {
            for(int i = 0; i < 4; i++)
            {
                index += gap;
                sum += index;
            }
            gap += 2;
        }
        return sum;
    }
}
