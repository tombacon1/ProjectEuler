﻿using System.Diagnostics;
using System.Numerics;

internal class EulerProject29
{
    static readonly string question = "   Consider all integer combinations of a^b for 2 ≤ a ≤ 5 and 2 ≤ b ≤ 5:\r\n\r\n" + 
        "     2^2=4, 2^3=8, 2^4=16, 2^5=32\r\n" + 
        "     3^2=9, 3^3=27, 3^4=81, 3^5=243\r\n" + 
        "     4^2=16, 4^3=64, 4^4=256, 4^5=1024\r\n" + 
        "     5^2=25, 5^3=125, 5^4=625, 5^5=3125\r\n\r\n" + 
        "   If they are then placed in numerical order, with any repeats removed, we\r\n" + 
        "   get the following sequence of 15 distinct terms:\r\n\r\n" + 
        "        4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125\r\n\r\n" + 
        "   How many distinct terms are in the sequence generated by a^b for 2 ≤ a ≤\r\n" + 
        "   100 and 2 ≤ b ≤ 100?";
    static readonly string separator = new string('-', 50) + "\r\n";

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        HashSet<BigInteger> set = new HashSet<BigInteger>();

        for (int a = 2; a <= 100; a++)
        for (int b = 2; b <= 100; b++)
        {
            BigInteger term = BigInteger.Pow(a, b); ;
            set.Add(term);
        }

        int result = set.Count;

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }
}