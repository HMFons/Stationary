namespace Stationary.Tests;

public class RecordShould
{
    [Fact]
    public void ReturnFullTime()
    {
        var record = new Models.Record(new TimeOnly(04, 20, 42), 69);
        var fullTime = record.GetFullTime(new DateTime(2024, 04, 05, 06, 07, 8));
        fullTime.Should().Be("2024-04-05T04:20:42.000+02:00");
    }
}

