using System.Diagnostics;

internal class EulerProject36
{
    static readonly string question = "    The decimal number, 585 = 100100100 (binary), is palindromic in both bases.\r\n\r\n" + 
                                      "    Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.\r\n\r\n" + 
                                      "    (Please note that the palindromic number, in either base, may not include leading zeros.)";
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
        public static int Solve()
        {
            int sum = 0;
            List<int> decimalPalindromes = GenerateDecimalPalindromes(6);

            foreach(int n in decimalPalindromes)
            {
                string binary = IntToBinaryString(n);
                if (IsPalindrome(binary))
                    sum += n;
            }

            return sum;
        }

        private static List<int> GenerateDecimalPalindromes(int length)
        {
            List<int> palindromes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i <= 999; i++)
            {
                string palindrome = i.ToString();
                List<char> mirror = new List<char>(palindrome.Reverse());

                palindrome += new string(mirror.ToArray());

                palindromes.Add(int.Parse(palindrome));

                if (palindrome.Length > 3)
                {
                    string palindromeOdd = palindrome.Remove(palindrome.Length / 2, 1);
                    palindromes.Add(int.Parse(palindromeOdd));
                }
            }

            return palindromes;
        }

        private static string IntToBinaryString(int n) => Convert.ToString(n, 2);

        private static bool IsPalindrome(string s)
        {
            string left = String.Empty;
            string right = String.Empty;
            int split = s.Length / 2;

            for (int i = 0; i < split; i++)
                left += new string(s[i], 1);

            for (int j = s.Length-1; s.Length - split - 1 < j; j--)
                right += new string(s[j], 1);

            return left.Equals(right);
        }
    }
}

