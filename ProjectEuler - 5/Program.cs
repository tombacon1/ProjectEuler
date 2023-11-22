using System.Diagnostics;

class EulerProject5
{
    static readonly string question = "2520 is the smallest number that can be divided by each of\r\n" + 
                                      "the numbers from 1 to 10 without any remainder.\r\n\r\n" +
                                      "What is the smallest positive number that is evenly divisible by all of the\r\n"+
                                      "numbers from 1 to 20?";
    static readonly string separator = new string('-', 50) + "\r\n";

    static int[] divisors = new int[20];

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < divisors.Length; i++)
            divisors[i] = i + 1;

        int largestDivisor = divisors.Length;
        int candidate = 0;
        int result = 0;

        while (result == 0)
        {
            candidate += largestDivisor;
            result = candidate;
            foreach (int n in divisors)
            {
                if (candidate % n != 0)
                {
                    result = 0;
                    break;
                }
            }
        }

        sw.Stop();

        Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
    }
}
