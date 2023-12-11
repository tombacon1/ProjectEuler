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




        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: ");
        Console.ReadLine();
    }
}
