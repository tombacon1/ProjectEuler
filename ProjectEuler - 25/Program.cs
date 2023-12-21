using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

internal class EulerProject25
{
    static readonly string question = "The Fibonacci sequence is defined by the recurrence relation:\r\n\r\n" + 
        "F_n = F_{n - 1} + F_{n - 2}, where F_1 = 1 and F_2 = 1.\r\n\r\n" + 
        "Hence the first 12 terms will be:\r\n\r\n" + 
        "F_1 = 1\r\nF_2 = 1\r\nF_3 = 2\r\nF_4 = 3\r\nF_5 = 5\r\nF_6 = 8\r\nF_7 = 13\r\nF_8 = 21\r\nF_9 = 34\r\nF_10 = 55\r\nF_11 = 89\r\nF_12 = 144\r\n\r\n\r\n" +  
        "The 12th term, F_12, is the first term to contain three digits.\r\n\r\n" + 
        "What is the index of the first term in the Fibonacci sequence to contain 1000 digits?";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int TARGET = 1000;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int digits = 0;
        Fibonacci fibonacci = new Fibonacci();

        while (digits < TARGET)
        {
            fibonacci.Next();
            digits = fibonacci.CurrentFibNumber.ToString().Length;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + fibonacci.Index);
        Console.ReadLine();
    }

    class Fibonacci
    {
        public int Index { get; set; }
        public BigInteger CurrentFibNumber { get; set; }
        public BigInteger PreviousFibNumber { get; set; }

        public Fibonacci()
        {
            CurrentFibNumber = 1; 
            PreviousFibNumber = 1;
            Index = 2;
        }

        public Fibonacci(BigInteger currentFibNumber, BigInteger previousFibNumber, int indexOfCurrent)
        {
            CurrentFibNumber = currentFibNumber;
            PreviousFibNumber = previousFibNumber;
            Index = indexOfCurrent;
        }

        public void Next() 
        {
            BigInteger tmp = PreviousFibNumber;
            PreviousFibNumber = CurrentFibNumber;
            CurrentFibNumber = BigInteger.Add(CurrentFibNumber, tmp);
            Index++;
        }
    }
}
