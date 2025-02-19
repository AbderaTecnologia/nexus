namespace Nexus.Core.Extensions;

public static class DateTimeExtensions
{
    private const int DaysInCommercialMonth = 30;

    public static DateTime AddCommercialMonths(this DateTime dateTime, double value)
        => dateTime.AddDays(DaysInCommercialMonth * value);

    public static int NumberOfDays(this DateTime fromDateTime, DateTime toDateTime)
        => fromDateTime.Date <= toDateTime.Date ? (toDateTime.Date - fromDateTime.Date).Days : 0;

    public static int NumberOfDaysConsideringFirstDay(this DateTime fromDateTime, DateTime toDateTime)
        => fromDateTime.Date <= toDateTime.Date ? (toDateTime.Date - fromDateTime.Date).Days + 1 : 0;

    public static DateTime GetBusinessWeekStartingDate(this DateTime fromDateTime)
        => fromDateTime.DayOfWeek switch
        {
            DayOfWeek.Tuesday => fromDateTime.AddDays(-1),
            DayOfWeek.Wednesday => fromDateTime.AddDays(-2),
            DayOfWeek.Thursday => fromDateTime.AddDays(-3),
            DayOfWeek.Friday => fromDateTime.AddDays(-4),
            DayOfWeek.Saturday => fromDateTime.AddDays(-5),
            DayOfWeek.Sunday => fromDateTime.AddDays(-6),
            _ => fromDateTime
        };

    public static int GetQuarter(this DateTime date)
        => (int)Math.Ceiling(date.Month / 3.0);

    public static DateTime GetQuarterEndingDate(this DateTime date)
    {
        var quarterOfTheYear = date.GetQuarter();
        int quarterEndingMonth = 3 * quarterOfTheYear;
        return new DateTime(date.Year, quarterEndingMonth, DateTime.DaysInMonth(date.Year, quarterEndingMonth));
    }

    public static DateTime GetQuarterStartingDate(this DateTime date)
    {
        var quarterEndingDate = date.GetQuarterEndingDate();
        int quarterStartingMonth = quarterEndingDate.Month - 2;
        return new DateTime(date.Year, quarterStartingMonth, 1);
    }

    public static IEnumerable<DateTime> EachDay(this DateTime from, DateTime to)
    {
        for (var day = from.Date; day <= to.Date; day = day.AddDays(1))
            yield return day;
    }

    public static IEnumerable<DateTime> EachPeriod(this DateTime from, DateTime to, int months)
    {
        for (var period = from.Date; period <= to.Date; period = period.AddMonths(months))
            yield return period;
    }

    public static IEnumerable<DateTime> EachQuarter(this DateTime from, DateTime to)
    {
        DateTime quarterStartingDate = from.GetQuarterStartingDate();

        for (var quarter = quarterStartingDate; quarter <= to.Date; quarter = quarter.AddMonths(3))
            yield return quarter;
    }

    public static IEnumerable<DateTime> EachYear(this DateTime from, DateTime to)
    {
        DateTime startingOftheYear = new DateTime(from.Year, 1, 1);

        for (var year = startingOftheYear; year <= to.Date; year = year.AddYears(1))
            yield return year;
    }

    public static bool IsMonday(this DateTime date) => date.DayOfWeek == DayOfWeek.Monday;
    public static bool IsFirstDayOfMonth(this DateTime date) => date.Day == 1;
    public static bool IsFirstDayOfAQuarter(this DateTime date) => date.Day == 1 && (date.Month == 1 || date.Month == 4 || date.Month == 7 || date.Month == 10);
    public static bool IsFirstDayOfYear(this DateTime date) => date.Day == 1 && date.Month == 1;
    public static bool IsLastDayOfMonth(this DateTime date) => date.Day == DateTime.DaysInMonth(year: date.Year, month: date.Month);
    public static DateTime EndOfDay(this DateTime date)
        => date.Date.AddDays(1).AddTicks(-1);
}