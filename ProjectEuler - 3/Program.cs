using System.Diagnostics;

internal class EulerProject30
{
    static readonly string question = "   Surprisingly there are only three numbers that can be written as the sum\r\n" + 
        "   of fourth powers of their digits:\r\n\r\n" + 
        "    1634 = 1^4 + 6^4 + 3^4 + 4^4\r\n" + 
        "    8208 = 8^4 + 2^4 + 0^4 + 8^4\r\n" + 
        "    9474 = 9^4 + 4^4 + 7^4 + 4^4\r\n\r\n" + 
        "  As 1 = 1^4 is not a sum it is not included.\r\n\r\n" + 
        "  The sum of these numbers is 1634 + 8208 + 9474 = 19316.\r\n\r\n" + 
        "  Find the sum of all the numbers that can be written as the sum of fifth\r\n" + 
        "  powers of their digits.";
    static readonly string separator = new string('-', 50) + "\r\n";


    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        int exp = 5;
        int maxDigitPowered = (int)Math.Pow(9, exp);

        int lowerBound = (int)Math.Pow(2, exp);
        int upperBound = maxDigitPowered.ToString().Length * maxDigitPowered;

        int result = 0;

        int[] powers = new int[10];

        for(int i = 1; i <= 9; i++)
            powers[i] = (int)Math.Pow(i, exp);

        for (int i = lowerBound; i <= upperBound; i++)
        {
            int sumOfPowers = 0;
            List<int> digits = GetDigits(i);
            
            foreach(int d in digits)
                sumOfPowers += powers[d];
         
            if (sumOfPowers == i)
                result += sumOfPowers;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    private static List<int> GetDigits(int i)
    {
        List<int> digits = new List<int>();

        while (i > 0)
        {
            int digit = i % 10;
            digits.Add(digit);
            i /= 10;
        }
        return digits;
    }
}
