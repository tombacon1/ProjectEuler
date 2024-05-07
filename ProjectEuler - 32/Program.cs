using System.Diagnostics;
using System.Net;

internal class EulerProject32
{
    static readonly string question = "   We shall say that an n-digit number is pandigital if it makes use of all\r\n" + 
        "  the digits 1 to n exactly once; for example, the 5-digit number, 15234, is\r\n" + 
        "  1 through 5 pandigital.\r\n\r\n" + 
        "  The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing\r\n" + 
        "  multiplicand, multiplier, and product is 1 through 9 pandigital.\r\n\r\n" + 
        "  Find the sum of all products whose multiplicand/multiplier/product\r\n" + 
        "  identity can be written as a 1 through 9 pandigital.\r\n\r\n" + 
        "  HINT: Some products can be obtained in more than one way so be sure to\r\n" + 
        "  only include it once in your sum.";
    static readonly string separator = new string('-', 50) + "\r\n";


    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        FindPanDigitalIdentities();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: ");
        Console.ReadLine();
    }

    private static void FindPanDigitalIdentities()
    {
        int[] digits = new int[9];
        List<int[]> digitArrays = new List<int[]>();

        PopulateDigitArrayRecursive(0, digits, 0, ref digitArrays);


        //for(int i = 1; )
    }

    private static void PopulateDigitArrayRecursive(int curDigit, int[] digits, int count, ref List<int[]> digitArrays)
    {
        if (count == 9)
        {
            digitArrays.Add(digits);
            string s = String.Empty;
            foreach(int digit in digits)
                s+= digit.ToString();
            
            Console.WriteLine(s);
            return;
        }

        
        if (!digits.Contains(curDigit))
        {
            digits[count] = curDigit;
            count++;
        }
        for (int i = 1; i <= 9; i++)
            PopulateDigitArrayRecursive(i, digits, count, ref digitArrays);
    }

    static bool IsPanDigital(int multiplicand, int multiplier)
    {
        int product = multiplicand * multiplier;

        char[] chars =  ConcatenateIntegersToCharArray(new int[3] { multiplicand, multiplier, product });

        for (int i = 1; i < 10; i++)
        {
            if (!chars.Contains((char)i))
                return false;
        }

        return true;
    }

    static char[] ConcatenateIntegersToCharArray(int[] input)
    {
        string s = String.Empty;
        
        for(int i = 0; i < input.Length; i++)
            s += input[i].ToString();

        return s.ToCharArray();
    }


    static int[] IntToDigitArray(int n)
    {
        Stack<int> digits = new Stack<int>();

        while(n != 0)
        {
            int d = n % 10;
            digits.Push(d);
            n /= 10;
        }
        return digits.ToArray();
    }
}
