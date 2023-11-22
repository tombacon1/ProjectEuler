using System.Diagnostics;

internal class EulerProject6
{
    static readonly string question = "The sum of the squares of the first ten natural numbers is,\r\n\r\n" + 
                                      "1^2 + 2^2 + ... + 10^2 = 385.\r\n\r\n" +
                                      "The square of the sum of the first ten natural numbers is,\r\n\r\n" + 
                                      "(1 + 2 + ... + 10)^2 = 55^2 = 3025.\r\n\r\n" + 
                                      "Hence the difference between the sum of the squares of the first ten\r\n" +
                                      "natural numbers and the square of the sum is:\r\n\r\n3025 - 385 = 2640\r\n\r\n" + 
                                      "Find the difference between the sum of the squares of the first one hundred\r\n" + 
                                      "natural numbers and the square of the sum.";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int MAX_NUMBER = 100;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();
        
        int sq_sum = 0;
        int sum_sq = 0;

        for (int i = 1; i <= MAX_NUMBER; i++)
        {
            sum_sq += i * i;
            sq_sum += i;
        }

        sq_sum *= sq_sum;
        
        int result = sq_sum - sum_sq;
        sw.Stop();
        
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }
}
