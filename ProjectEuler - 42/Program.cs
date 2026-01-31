using System.Diagnostics;

internal class EulerProject42
{
    static readonly string question = "The nth term of the sequence of triangle numbers is given by, t_n = 0.5n(n+1);\r\n" + 
                                      "so the first ten triangle numbers are: 1, 3, 6, 10, 15, 21, 28, 36, 45, 55...\r\n\r\n" + 
                                      "By converting each letter in a word to a number corresponding to its alphabetical position and adding \r\n" +
                                      "these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t_10.\r\n" + 
                                      "If the word value is a triangle number then we shall call the word a triangle word.\r\n\r\n" + 
                                      "Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common \r\n" + 
                                      "English words, how many are triangle words?";
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

    private static class Solution
    {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        static string projectDirectoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        static string filePath = projectDirectoryPath + "\\0042_words.txt";
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        internal static int Solve()
        {
            List<string> words = GetWords();
            List<int> triangleNumbers = new List<int>();
            
            int currentMaxTriangleNumber = 0;
            int lastTriangleNumberPositionCalculated = 0;
            int count = 0;

            foreach (string word in words)
            {
                int sum = GetAlphaSumForWord(word);

                while(currentMaxTriangleNumber < sum)
                {
                    int n = lastTriangleNumberPositionCalculated + 1;
                    int t = (int)((0.5 * n) * (n + 1));
                    currentMaxTriangleNumber = Math.Max(currentMaxTriangleNumber, t);
                    triangleNumbers.Add(t);
                    lastTriangleNumberPositionCalculated = n;
                }

                if (triangleNumbers.Contains(sum))
                    count++;
            }

            return count;
        }

        private static int GetAlphaSumForWord(string word)
        {
            int sum = 0;
            foreach(char c in word)
            {
                int alphaPosition = (int)c - 64;
                sum += alphaPosition;
            }

            return sum;
        }

        private static List<string> GetWords()
        {
            string text = File.ReadAllText(filePath).Replace("\"", String.Empty);
            return text.Split(",", StringSplitOptions.TrimEntries).ToList();
        }
    }
}

