using Xunit.Abstractions;

namespace Stationary.Tests.ParseJson;

public class DeserializeShould
{
    private readonly ITestOutputHelper _output;
    public DeserializeShould(ITestOutputHelper output) => _output = output;
    [Fact]
    public void ParseFullJson()
    {
        string fileName = "parseJson/data/Full.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var activity = JsonSerializer.Deserialize<Activity>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        var serialized = JsonSerializer.Serialize(activity);
        _output.WriteLine(serialized);
        activity.Should().NotBeNull();
        activity.ActivitiesHeart.Should().NotBeNull();
        activity.ActivitiesHeartIntraday.Should().NotBeNull();

        activity.ActivitiesHeart.First().HeartRateZones.First().CaloriesOut.Should().Be(322.91874005);
        activity.ActivitiesHeart.First().HeartRateZones.First().Max.Should().Be(105);
        activity.ActivitiesHeart.First().HeartRateZones.First().Min.Should().Be(30);
        activity.ActivitiesHeart.First().HeartRateZones.First().Minutes.Should().Be(30);
        activity.ActivitiesHeart.First().HeartRateZones.First().Name.Should().Be("Out of Range");
    }

    [Fact]
    public void ParseActivityPartOne()
    {
        string fileName = "parseJson/data/ActivityPartOne.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var activity = JsonSerializer.Deserialize<Activity>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        activity.Should().NotBeNull();
        activity.ActivitiesHeart.Should().NotBeNull();

        activity.ActivitiesHeart.First().HeartRateZones.First().CaloriesOut.Should().Be(322.91874005);
        activity.ActivitiesHeart.First().HeartRateZones.First().Max.Should().Be(105);
        activity.ActivitiesHeart.First().HeartRateZones.First().Min.Should().Be(30);
        activity.ActivitiesHeart.First().HeartRateZones.First().Minutes.Should().Be(30);
        activity.ActivitiesHeart.First().HeartRateZones.First().Name.Should().Be("Out of Range");
    }
    [Fact]
    public void ParseActivityPartTwo()
    {
        string fileName = "parseJson/data/ActivityPartTwo.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var activity = JsonSerializer.Deserialize<Activity>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        activity.Should().NotBeNull();
        activity.ActivitiesHeartIntraday.Should().NotBeNull();

        activity.ActivitiesHeartIntraday.Dataset.First().Value.Should().Be(88);
        activity.ActivitiesHeartIntraday.Dataset.First().Time.Should().Be(new TimeOnly(20, 59, 42));

        activity.ActivitiesHeartIntraday.Dataset.Last().Value.Should().Be(113);
        activity.ActivitiesHeartIntraday.Dataset.Last().Time.Should().Be(new TimeOnly(22, 00, 15));

        activity.ActivitiesHeartIntraday.DatasetInterval.Should().Be(1);
        activity.ActivitiesHeartIntraday.DatasetType.Should().Be("second");
    }
    [Fact]
    public void ParseHeartRateZone()
    {
        string fileName = "parseJson/data/HeartRateZone.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var heartRateZone = JsonSerializer.Deserialize<HeartRateZone>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        heartRateZone!.CaloriesOut.Should().Be(322.91874005);
        heartRateZone!.Max.Should().Be(105);
        heartRateZone!.Min.Should().Be(30);
        heartRateZone!.Minutes.Should().Be(30);
        heartRateZone!.Name.Should().Be("Out of Range");
    }
    [Fact]
    public void ParseHeartRateZones()
    {
        string fileName = "parseJson/data/HeartRateZones.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var heartRateZones = JsonSerializer.Deserialize<List<HeartRateZone>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        heartRateZones.Count.Should().Be(3);
        var heartRateZone = heartRateZones.First();
        heartRateZone!.CaloriesOut.Should().Be(610.6976323500002);
        heartRateZone!.Max.Should().Be(144);
        heartRateZone!.Min.Should().Be(30);
        heartRateZone!.Minutes.Should().Be(59);
        heartRateZone!.Name.Should().Be("Below");
    }
    [Fact]
    public void ParseHeartActivity()
    {
        string fileName = "parseJson/data/HeartActivity.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var heartActivity = JsonSerializer.Deserialize<HeartRateZoneGroup>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        heartActivity.HeartRateZones.Count().Should().Be(4);
        heartActivity.CustomHeartRateZones.Count().Should().Be(3);
        heartActivity.Value.Should().Be("110.04");
        heartActivity.DateTime.ToString("yyyy-MM-dd").Should().Be("2024-04-17");
    }
    [Fact]
    public void ParseHeartActivities()
    {
        string fileName = "parseJson/data/HeartActivities.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var heartActivities = JsonSerializer.Deserialize<List<HeartRateZoneGroup>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        heartActivities.First().HeartRateZones.Count().Should().Be(4);
        heartActivities.First().CustomHeartRateZones.Count().Should().Be(3);
        heartActivities.First().Value.Should().Be("110.04");
        heartActivities.First().DateTime.ToString("yyyy-MM-dd").Should().Be("2024-04-17");
    }

    [Fact]
    public void ParseRecord()
    {
        string fileName = "parseJson/data/Record.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var record = JsonSerializer.Deserialize<Models.Record>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        record.Value.Should().Be(88);
        record.Time.Should().Be(new TimeOnly(20, 59, 42));
    }
    [Fact]
    public void ParseRecords()
    {
        string fileName = "parseJson/data/Records.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var record = JsonSerializer.Deserialize<List<Models.Record>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        record.First().Value.Should().Be(88);
        record.First().Time.Should().Be(new TimeOnly(20, 59, 42));

        record.Last().Value.Should().Be(113);
        record.Last().Time.Should().Be(new TimeOnly(22, 00, 15));
    }
    [Fact]
    public void ParseIntradayHeartActivities()
    {
        string fileName = "parseJson/data/IntradayHeartActivities.json";
        string jsonString = File.ReadAllText(fileName);
        _output.WriteLine(jsonString);
        var activities = JsonSerializer.Deserialize<ActivitiesHeartIntraday>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

        activities.Dataset.First().Value.Should().Be(88);
        activities.Dataset.First().Time.Should().Be(new TimeOnly(20, 59, 42));

        activities.Dataset.Last().Value.Should().Be(113);
        activities.Dataset.Last().Time.Should().Be(new TimeOnly(22, 00, 15));

        activities.DatasetInterval.Should().Be(1);
        activities.DatasetType.Should().Be("second");
    }
}
