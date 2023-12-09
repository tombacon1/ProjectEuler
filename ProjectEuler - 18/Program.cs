using System.Diagnostics;

internal class EulerProject18
{
    static readonly string question = "By starting at the top of the triangle below and moving to adjacent numbers on the row below,\r\n" + 
        "the maximum total from top to bottom is 23.\r\n\r\n   3\r\n  7 4\r\n 2 4 6\r\n8 5 9 3\r\n\r\n" + 
        "That is, 3 + 7 + 4 + 9 = 23.\r\n\r\nFind the maximum total from top to bottom of the triangle below:\r\n\r\n" + 
        "              75\r\n             95 64\r\n            17 47 82\r\n           18 35 87 10\r\n          20 04 82 47 65\r\n" + 
        "         19 01 23 75 03 34\r\n        88 02 77 73 07 63 67\r\n       99 65 04 28 06 16 70 92\r\n      41 41 26 56 83 40 80 70 33\r\n" + 
        "     41 48 72 33 47 32 37 16 94 29\r\n    53 71 44 65 25 43 91 52 97 51 14\r\n   70 11 33 28 77 73 17 78 39 68 17 57\r\n" + 
        "  91 71 52 38 17 14 91 43 58 50 27 29 48\r\n 63 66 04 68 89 53 67 30 73 16 69 87 40 31\r\n04 62 98 27 23 09 70 98 73 93 38 53 60 04 23\r\n\r\n" + 
        "NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. \r\n" + 
        "However, Problem 67, is the same challenge with a triangle containing one-hundred rows;\r\nit cannot be solved by brute force, and requires a clever method! ;o)";
    static readonly string separator = new string('-', 50) + "\r\n";

    static int[][] data = new int[15][];

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        Stopwatch sw = Stopwatch.StartNew();

        InitialiseData();

        List<int> bottomRow = new List<int>();

        for(int i = data.Length - 2; i >= 0; i--)
        {
            for (int j = 0; j < data[i].Length; j++) {
                int max = Math.Max(data[i][j] + data[i + 1][j], data[i][j] + data[i + 1][j + 1]);
                bottomRow.Add(max);
            }
            data[i] = bottomRow.ToArray();
            bottomRow.Clear();
        }
        
        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result: " + data[0][0]);
        Console.ReadLine();
    }

    private static void InitialiseData()
    {
        data[0] = new int[] { 75 };
        data[1] = new int[] { 95, 64 };
        data[2] = new int[] { 17, 47, 82 };
        data[3] = new int[] { 18, 35, 87, 10 };
        data[4] = new int[] { 20, 04, 82, 47, 65 };
        data[5] = new int[] { 19, 01, 23, 75, 03, 34 };
        data[6] = new int[] { 88, 02, 77, 73, 07, 63, 67 };
        data[7] = new int[] { 99, 65, 04, 28, 06, 16, 70, 92 };
        data[8] = new int[] { 41, 41, 26, 56, 83, 40, 80, 70, 33 };
        data[9] = new int[] { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 };
        data[10]= new int[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 };
        data[11]= new int[] { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 };
        data[12]= new int[] { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 };
        data[13]= new int[] { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 };
        data[14]= new int[] { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23 };
    }
}
