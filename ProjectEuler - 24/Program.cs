using System.Diagnostics;
using System.Net;

internal class EulerProject24
{
    static readonly string question = "A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation\r\n" + 
        "of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically,\r\n" + 
        "we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:\r\n\r\n" + 
        "   012   021   102   120   201   210\r\n\r\n" + 
        "What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?";
    static readonly string separator = new string('-', 50) + "\r\n";

    const string INPUT = "0123456789";
    const int ONE_MILLION = 1000000;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int count = 0;
        string result = String.Empty;
        StringPermutation("", INPUT, ref count, ref result); ;

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    private static void StringPermutation(string prefix, string input, ref int count, ref string result)
    {
        int n = input.Length;
        if (n == 0)
        {
            count++;
            if (count == ONE_MILLION)
                result = prefix;
        }
        else if (count < ONE_MILLION)
        {
            for (int i = 0; i < n; i++)
                StringPermutation(prefix + input[i], input.Substring(0, i) + input.Substring(i + 1, n - (i + 1)), ref count, ref result);
        }
    }
}
