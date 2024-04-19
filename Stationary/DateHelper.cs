namespace Stationary;

public static class DateHelper
{
    public static string JoinDateTimeAndTimeOnly(DateTime date, TimeOnly time)
    {
        var dateTime = date.ToString("yyyy-MM-dd");
        dateTime += "T";
        dateTime += time.ToString("HH:mm:ss.fff");
        dateTime += date.ToString("zzz");
        return dateTime;
    }
}
