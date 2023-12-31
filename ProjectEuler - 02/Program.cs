﻿using System.Collections.Generic;
using System;
using System.Diagnostics;

class EulerProject2
{
    static readonly string question = "Each new term in the Fibonacci sequence is generated by adding the previous two terms.\r\n" +
            "By starting with 1 and 2, the first 10 terms will be: 1,2,3,5,8,13,21,34,55,89,...\r\n" +
            "By considering the terms in the Fibonacci sequence whose values do not exceed four million,\r\n" + 
            "find the sum of the even-valued terms.\r\n";
    static readonly string separator = new string('-', 50) + "\r\n";


    const int MAX_RANGE = 4000000;
    static List<int> fibList = new List<int>();

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);

        Stopwatch sw = Stopwatch.StartNew();

        fibList = GenerateFibonacciSequence(MAX_RANGE);
        int evenValueSum = SumEvenValues(fibList);

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + evenValueSum);
        Console.ReadLine();
    }

    private static int SumEvenValues(List<int> fibList)
    {
        int sum = 0;
        
        for (int i = 2; i < fibList.Count; i += 3)
            sum += fibList[i];
        
        return sum;
    }

    private static List<int> GenerateFibonacciSequence(int maxRange)
    {
        List<int> fibSeq = new List<int>();
        fibSeq.Add(1);

        int i = 0;
        int next = i+1;
        while (next < maxRange)
        {
            fibSeq.Add(next);
            i++;
            next = fibSeq[i] + fibSeq[i - 1];
        }
        return fibSeq;
    }
}