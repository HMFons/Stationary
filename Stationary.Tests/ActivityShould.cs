namespace Stationary.Tests;

public class ActivityShould
{
    [Fact]
    public void ReturnStartTime()
    {
        var activity = new Activity()
        {
            ActivitiesHeart = new() { new(Enumerable.Empty<HeartRateZone>(), new DateTime(2024, 04, 05, 06, 07, 08), Enumerable.Empty<HeartRateZone>(), string.Empty) },
            ActivitiesHeartIntraday = new(1, new() { new(new TimeOnly(04, 20, 42), 69) }, "second")
        };

        activity.StartTime.Should().Be("2024-04-05T04:20:42.000+02:00");
    }
    [Fact]
    public void ReturnDuration()
    {
        var activity = new Activity()
        {
            ActivitiesHeartIntraday = new(1, new() { new(new TimeOnly(04, 20, 42), 69), new(new TimeOnly(04, 20, 45), 70), new(new TimeOnly(04, 20, 49), 71) }, "second")
        };

        activity.Duration.Should().Be(7);
    }
    [Theory]
    [InlineData(50.5, 1.7, 5, 57)] // round down
    [InlineData(50.2, 1.7, 5, 57)] // round up
    public void ReturnTotalCaloriesOut(double val1, double val2, double val3, int expected)
    {
        var activity = new Activity()
        {
            ActivitiesHeart = new() { new(Enumerable.Empty<HeartRateZone>(), new DateTime(), new List<HeartRateZone>() { new(val1, int.MinValue, int.MinValue, int.MinValue, string.Empty), new(val2, int.MinValue, int.MinValue, int.MinValue, string.Empty), new(val3, int.MinValue, int.MinValue, int.MinValue, string.Empty) }, string.Empty) },
        };

        activity.TotalCaloriesOut.Should().Be(expected);
    }
}
