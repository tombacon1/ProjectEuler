using System.Diagnostics;

internal class EulerProject19
{
    static readonly string question = "You are given the following information, but you may prefer to do some research for yourself.\r\n\r\n" +
        " - 1 Jan 1900 was a Monday.\r\n" + 
        " - Thirty days has September,\r\n   April, June and November.\r\n   All the rest have thirty-one,\r\n   Saving February alone,\r\n" + 
        "   Which has twenty-eight, rain or shine.\r\n   And on leap years, twenty-nine.\r\n" + 
        " - A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.\r\n\r\n" + 
        "How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?";
    static readonly string separator = new string('-', 50) + "\r\n";

    static readonly int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    const int DAYS_PER_WEEK = 7;
    const int DAYS_PER_YEAR = 365;

    static void Main()
    {
        Console.WriteLine(question);
        Console.WriteLine(separator);
        int result;
        
        Stopwatch sw = Stopwatch.StartNew();

        result = Attempt1();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result 1: " + result);

        sw.Restart();

        result = Attempt2();

        sw.Stop();
        Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
        Console.WriteLine("Result 2: " + result);
        Console.ReadLine();
    }

    private static int Attempt2()
    {
        int leapDay;
        int curDay = 6;
        int monthDays = 31;
        int count = 0;

        for (int year = 1901; year <= 2000; year++)
        {
            leapDay = IsLeapYear(year) ? 1 : 0;
            for (int i = 0; i < daysInMonth.Length; i++)
            {
                monthDays = daysInMonth[i];
                if (i == 1)
                    monthDays += leapDay;

                while (curDay < monthDays)
                    curDay += DAYS_PER_WEEK;

                curDay -= monthDays;
                if (curDay == 1)
                    count++;
            }
        }

        return count;
    }

    private static int Attempt1()
    {
        int lastSundayOfLastMonth = 30; // DEC 30 1900
        int daysLastMonth = 31;         // DEC 1900
        int leapDay = 0;
        int count = 0;
        int firstSunday = 0;
        int daysThisMonth = 0;

        for (int year = 1901; year <= 2000; year++)
        {
            leapDay = IsLeapYear(year) ? 1 : 0;
            for (int i = 0; i < daysInMonth.Length; i++)
            {
                daysThisMonth = daysInMonth[i];
                if (i == 1) daysThisMonth += leapDay;

                firstSunday = 7 - (daysLastMonth - lastSundayOfLastMonth);
                if (firstSunday == 1) count++;
                lastSundayOfLastMonth = ((daysThisMonth - firstSunday) / DAYS_PER_WEEK) * DAYS_PER_WEEK + firstSunday;
                daysLastMonth = daysThisMonth;
            }
        }

        return count;
    }

    private static bool IsLeapYear(int year)
    {
        if (year % 100 == 0)
        {
            if (year % 400 == 0)
                return true;
        }
        else if (year % 4 == 0)
        {
            return true;
        }

        return false;
    }
}
