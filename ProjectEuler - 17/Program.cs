using System.Diagnostics;
using System.Text;

internal class EulerProject17
{
    static readonly string question = "If the numbers 1 to 5 are written out in words: one, two, three, four, five, then\r\n" +
                                      "there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.\r\n\r\n" + 
                                      "If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words,\r\n" + 
                                      "how many letters would be used?\r\n\r\n\r\n" + 
                                      "NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two)" +  
                                      "contains 23 letters and 115 (one hundred and fifteen) contains 20 letters." + 
                                      "The use of \"and\" when writing out numbers is in compliance with British usage.";
    static readonly string separator = new string('-', 50) + "\r\n";
    static string[] zeroThroughNine = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    static string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    static string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };


    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        string words = String.Empty;


        int count = 0;
        for (int i = 1; i <= 1000; i++)
        {
            //Console.WriteLine("Number: " + i.ToString());
            string numberAsString = GetIntegerAsString(i);
            //Console.WriteLine(numberAsString);
            count += numberAsString.Replace(" ", "").Length;
            //Console.WriteLine("Current count: " + count);
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + count);
        Console.ReadLine();
    }

    private static string GetIntegerAsString(int n)
    {
        string numAsString = n.ToString();
        string[] digitWords = new string[3] {String.Empty, String.Empty, String.Empty};
        int[] digits = new int[numAsString.Length];
        int tensDigit = 0;
        int singlesDigit = 0;
        bool isTeen = false;

        for (int i = 0; i < numAsString.Length; i++)
            digits[i] = Convert.ToInt32(char.GetNumericValue(numAsString[i]));

        if (digits.Length > 3)
            return "one thousand";
        if (digits.Length > 2)
            digitWords[0] = zeroThroughNine[digits[digits.Length - 3]];
        if (digits.Length > 1) 
        {
            tensDigit = digits[digits.Length - 2];
            if (tensDigit == 1) 
            {
                isTeen = true;
                singlesDigit = digits[digits.Length - 1];
                digitWords[1] = teens[singlesDigit];
            }
            else
                digitWords[1] = tens[tensDigit];
        }
        if (digits.Length > 0)
            digitWords[2] = zeroThroughNine[digits[digits.Length - 1]];

        StringBuilder words = new StringBuilder();

        if (!String.IsNullOrEmpty(digitWords[0]))
            words.Append(digitWords[0] + " hundred" + (n % 100 == 0 ? "" : " and "));
        if (!String.IsNullOrEmpty(digitWords[1]))
            words.Append(digitWords[1] + " ");
        if (!isTeen)
            words.Append(digitWords[2]);

        return words.ToString().Trim();
    }
}
