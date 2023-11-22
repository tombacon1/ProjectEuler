using System.Diagnostics;

class EulerProject4
{
    static readonly string separator = new string('-', 50) + "\r\n";
    static readonly string question = "A palindromic number reads the same both ways. The largest palindrome made from the product\r\n" + 
                                      "of two 2-digit numbers is 9009 = 91 * 99.\r\n\r\n" +
                                      "Find the largest palindrome made from the product of two 3-digit numbers.\r\n";

    const int NUM_DIGITS = 3;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);

        int start = int.Parse("1" + new string('0', NUM_DIGITS - 1));
        int end = int.Parse(new string('9', NUM_DIGITS));
        long result = 0;

        Stopwatch stopwatch = Stopwatch.StartNew();
        for (long i = end; i >= start; i--)
            for (long j = start; j <= i; j++)   // work from min value to current index of outer loop to prevent double-testing
                if (i * j > result)         // product is larger than current result so test for palindrome
                {      
                    if (IsPalindromic(i * j))
                    {
                        Console.WriteLine(i.ToString() + " x " + j.ToString());
                        result = i * j;
                    }
                }
                else if (j == i)    // not going to find a larger product so...
                    i = start - 1;  // break out of the for loops

        stopwatch.Stop();
        Console.WriteLine("\r\nIsPalindromic: " + stopwatch.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result + "\r\n");

        result = 0;
        stopwatch.Reset();
        stopwatch.Start();
        for (long i = end; i >= start; i--)
            for (long j = start; j <= i; j++)
                if (i * j > result)
                {
                    if (IsPalindromicCompareReverseMethod(i * j))
                    {
                        Console.WriteLine(i.ToString() + " x " + j.ToString());
                        result = i * j;
                    }
                }
                else if (j == i)    
                    i = start - 1;  

        stopwatch.Stop();
        Console.WriteLine("\r\nIsPalindromicCompareReverseMethod: " + stopwatch.ElapsedMilliseconds + "ms");

        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    private static bool IsPalindromic(long value)
    {
        string candidate = value.ToString();
        int length = candidate.Length;
       
        int half = length / 2;

        for (int i = 0; i < half; i++)
        {
            if (candidate[i] != candidate[length - 1 - i])
                return false;
        }
        return true;
    }

    private static bool IsPalindromicCompareReverseMethod(long value)
    {
        string candidate = value.ToString();

        string reversed = new String(candidate.Reverse().ToArray());
        if (candidate == reversed)
            return true;

        return false;
    }
}