using System.Diagnostics;

class EulerProject1
{
    static readonly string question = "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9." + "" +
            "\r\nThe sum of these multiples is 23.\r\n\r\nFind the sum of all the multiples of 3 or 5 below 1000.\r\n";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int MAX_SIZE = 1000;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);

        Stopwatch sw = Stopwatch.StartNew();

        int sum = 0;

        for (int i = MAX_SIZE - 1; i > 0; i--)
            if (i % 3 == 0 || i % 5 == 0)
                sum += i;

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + sum);
    }
}