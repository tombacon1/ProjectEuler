using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

internal class EulerProject16
{
    static readonly string question = "2^{15} = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.\r\n\r\n" +
                                      "What is the sum of the digits of the number 2^{1000}?";
    static readonly string separator = new string('-', 50) + "\r\n";

    const int base2Power = 1000;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        BigInteger twoToTheThousandthPower = TwoPowerX(base2Power);
        
        string digitString = twoToTheThousandthPower.ToString();
        Console.WriteLine("2^{1000} = " + digitString);

        int result = 0;

        foreach(char digit in digitString)
            result += (int) char.GetNumericValue(digit);
                    
        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }

    private static BigInteger TwoPowerX(int power)
    {
        return (BigInteger) 1 << power;
    }
}
