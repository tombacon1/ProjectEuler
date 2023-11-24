using System.Diagnostics;

internal class EulerProject14
{
    static readonly string question = "The following iterative sequence is defined for the set of positive integers:\r\n\r\n" + 
                                      "(n -> n/2 is even)\r\n" +  
                                      "(n -> 3n + 1 is odd)\r\n\r\n" + 
                                      "Using the rule above and starting with 13, we generate the following sequence:\r\n\r\n" + 
                                      "13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1.\r\n\r\n" + 
                                      "It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms.\r\n" + 
                                      "Although it has not been proved yet (Collatz Problem), it is thought that all starting\r\n" + 
                                      "numbers finish at 1.\r\n\r\n" + 
                                      "Which starting number, under one million, produces the longest chain?\r\n\r\n" + 
                                      "NOTE: Once the chain starts the terms are allowed to go above one million.";
    static readonly string separator = new string('-', 50) + "\r\n";
    const int MAX_START = 1000000;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int start = 0;
        int maxChainLength = 0;
        int startNumber = 0;

        while(start < MAX_START)
        {
            start++;
            int chainLength = 1;
            long last = start;
            while(last > 1)
            {
                if (IsEven(last))
                    last /= 2;
                else
                    last = last * 3 + 1;
                
                chainLength++;
            }

            if (chainLength > maxChainLength)
            {
                maxChainLength = chainLength;
                startNumber = start;
            }
        }
        
        sw.Stop();
        
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + "Start Number = " + startNumber + "\r\n" + new String(' ', 8) + "Chain Length = " + maxChainLength);
        Console.ReadLine();
    }

    private static bool IsEven(long n)
    {
        return n % 2 == 0;
    }
}
