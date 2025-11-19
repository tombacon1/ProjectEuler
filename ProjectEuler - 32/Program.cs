using System.Diagnostics;

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

    const string SORTED_DIGITS = "123456789";


    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        HashSet<int> products = FindPanDigitalProducts();

        int sum = 0;
        foreach (int product in products) { sum+= product; }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + sum);
        Console.ReadLine();
    }

    private static HashSet<int> FindPanDigitalProducts()
    {
        HashSet<int> panDigitalProducts = new HashSet<int>();

        const int MAX_PRODUCT = 9876;
        const int MIN_PRODUCT = 1234;

        for (int n = MIN_PRODUCT; n <= MAX_PRODUCT; n++)
            if (HasUniqueDigits(n))
                for (int i = 1; i * i < n; i++)
                {
                    if (n % i == 0 && IsPanDigital(i, n / i, n))
                        panDigitalProducts.Add(n);
                }
        return panDigitalProducts;
    }

    static bool IsPanDigital(int multiplicand, int multiplier, int product)
    {
        string digits = multiplicand.ToString() + multiplier.ToString() + product.ToString();

        if (digits.Length != 9)
            return false;

        char[] digitsCharArray = digits.ToCharArray();
        Array.Sort(digitsCharArray);

        return new String(digitsCharArray).Equals(SORTED_DIGITS);

    }

    private static bool HasUniqueDigits(int n)
    {
        char[] chars = Convert.ToString(n).ToCharArray();
        HashSet<char> set = new HashSet<char>(chars);
        return set.Count == chars.Length;
    }
}
