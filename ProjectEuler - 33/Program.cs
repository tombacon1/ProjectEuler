using System.Diagnostics;

internal class EulerProject33
{
    static readonly string question = "   The fraction 49/98 is a curious fraction, as an inexperienced\r\n" +
        "   mathematician in attempting to simplify it may incorrectly believe that\r\n" +
        "   49/98 = 4/8, which is correct, is obtained by cancelling the 9s.\r\n\r\n" +
        "   We shall consider fractions like, 30/50 = 3/5, to be trivial\r\n" +
        "   examples.\r\n\r\n" +
        "   There are exactly four non-trivial examples of this type of fraction, less\r\n" +
        "   than one in value, and containing two digits in the numerator and\r\n" +
        "   denominator.\r\n\r\n" +
        "   If the product of these four fractions is given in its lowest common\r\n" +
        "   terms, find the value of the denominator.";
    static readonly string separator = new string('-', 50) + "\r\n";

    const string ARG_OUT_OF_RANGE_MSG = "Digit index parameter must be a positive integer greater than 0 and no greater than the number of digits of the number parameter.";
    const int MAX_DIGITS = 2;

    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        internal static Fraction Simplify(Fraction products)
        {
            int gcd = GCD(products.Numerator, products.Numerator);
            return new Fraction(products.Numerator / gcd, products.Denominator / gcd);
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public double AsDecimal() => AsDecimal(this);

        public static double AsDecimal(int numerator, int denominator) => (double)numerator / (double)denominator;
        public static double AsDecimal(Fraction fraction) => AsDecimal(fraction.Numerator, fraction.Denominator);
               
    }

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        List<Fraction> curious_fractions = new List<Fraction>();

        int[] num_digits = new int[MAX_DIGITS];
        int[] den_digits = new int[MAX_DIGITS];

        for (int numerator = 11; numerator < 98; numerator++)
        {
            if (numerator % 10 == 0)
                continue;

            for (int denominator = numerator + 1; denominator < 99; denominator++)
            {
                if (denominator % 10 == 0)
                    continue;

                den_digits[0] = GetDigitFromInt(denominator, 0);
                den_digits[1] = GetDigitFromInt(denominator, 1);
                num_digits[0] = GetDigitFromInt(numerator, 0);
                num_digits[1] = GetDigitFromInt(numerator, 1);

                for(int i = 0; i <=1 ; i++)
                    for(int j = 0; j <= 1; j++)
                    {
                        if (num_digits[i] == den_digits[j])
                        {
                            if (Fraction.AsDecimal(num_digits[1 - i], den_digits[1 - j]).Equals(Fraction.AsDecimal(numerator, denominator)))
                                curious_fractions.Add(new Fraction(num_digits[1-i], den_digits[1-j]));
                        }
                    }
            }
        }

        Fraction products = new Fraction(1, 1);

        foreach (Fraction f in curious_fractions)
        {
            products.Denominator *= f.Denominator;
            products.Numerator *= f.Numerator;
        }

        Fraction simplified_fraction = Fraction.Simplify(products);

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + simplified_fraction.Denominator.ToString());
        Console.ReadLine();
    }

    static int GetDigitFromInt(int number, int digitIndex)
    {
        if (digitIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(digitIndex));

        Stack<int> stack = new Stack<int>(2);

        while (number > 0)
        {
            stack.Push(number % 10);
            number /= 10;
        }

        int[] digits = stack.ToArray();
        return digits[digitIndex];
    }
}
