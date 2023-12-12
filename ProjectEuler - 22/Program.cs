using System.Diagnostics;

internal class EulerProject22
{
    static readonly string question = "Using names.txt [https://projecteuler.net/resources/documents/0022_names.txt]\r\n" + 
        "(right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names,\r\n" + 
        "begin by sorting it into alphabetical order. Then working out the alphabetical value for each name,\r\n" + 
        "multiply this value by its alphabetical position in the list to obtain a name score.\r\n\r\n" +
        "For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53,\r\n" +
        "is the 938th name in the list. So, COLIN would obtain a score of 938 * 53 = 49714.\r\n\r\n" + 
        "What is the total of all the name scores in the file?";
    static readonly string separator = new string('-', 50) + "\r\n";


    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        string projectDirectoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        string textFilePath = Path.Combine(projectDirectoryPath,"ref\\names.txt");
        string fileString = String.Empty;

        using (StreamReader reader = new StreamReader(textFilePath))
            fileString = reader.ReadToEnd();

        string cleanFileString = fileString.Replace("\"", String.Empty);

        List<string> names = cleanFileString.Split(',').ToList();
        names.Sort();

        int position = 1;
        int sumOfScores = 0;
        int asciiIndexDelta = (int)'A' - 1;

        foreach (string name in names)
        {
            int score = 0;
            foreach(char c in name.ToUpper())
                score += (int)c - asciiIndexDelta;
            
            sumOfScores += position * score;
            position++;
        }

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + sumOfScores);
        Console.ReadLine();
    }
}
