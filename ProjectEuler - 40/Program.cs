using System.Diagnostics;

internal class EulerProject38
{
    static readonly string question = "    An irrational decimal fraction is created by concatenating the positive integers:\r\n" + 
                                      "        0.123456789101112131415161718192021...\r\n\r\n" +
                                      "    It can be seen that the 12th digit of the fractional part is 1.\r\n\r\n" + 
                                      "    If dn represents the nth digit of the fractional part, find the value of the following expression.\r\n" + 
                                      "        d1*d10*d100*d1000*d10000*d100000*d1000000";
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
            int section = 1;
            int offset = 0;
            int pow10 = 1;
            int solution = 1;

            List<int> targetOffsets = new List<int> { 0, 9, 99, 999, 9999, 99999, 999999 };

            foreach (int digitOffset in targetOffsets)
            {
                int sectionSize = 9 * pow10 * section;

                while (offset + sectionSize <= digitOffset)
                {
                    ++section;
                    pow10 *= 10;
                    offset += sectionSize;
                    sectionSize = 9 * pow10 * section;
                }

                int sectionOffset = digitOffset - offset;
                int n = sectionOffset / section + pow10;
                string str = n.ToString();
                solution *= int.Parse(str[sectionOffset % section].ToString());
            }
            return solution;
        }
    }
}

