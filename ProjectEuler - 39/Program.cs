using System.Diagnostics;

internal class EulerProject39
{
    static readonly string question = "    If p is the perimeter of a right angle triangle with integral length sides, {a,b,c},\r\n" + 
                                      "    there are exactly three solutions for p =120.\r\n\r\n    {20,48,52}, {24,45,51}, {30,40,50}\r\n\r\n" + 
                                      "    For which value of p ≤ 1000, is the number of solutions maximised?";
    static readonly string separator = new string('-', 50) + "\r\n";


    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int result = Solution.Solve();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    static class Solution
    {
        internal static int Solve()
        {
            int maxCount = 0;
            int maximisedPerimeter = 0;

            for (int p = 4; p < 1000; p++)
            {
                int count = 0;
                for (int a = 1; a < p - 2; a++)
                    for (int b = 1; b < p - 1 - a; b++)
                    {
                        int c = p - a - b;

                        if (IsPythagorean(a, b, c))
                            count++;
                    }

                maxCount = Math.Max(maxCount, count);

                if (count == maxCount)
                    maximisedPerimeter = p;
             
            }

            return maximisedPerimeter;
        }
        
        private static bool IsPythagorean(int a, int b, int c) => a * a + b * b == c * c;
    
    }
}

