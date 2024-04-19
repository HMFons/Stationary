using System.Text.Json.Serialization;

namespace Stationary.Models;

public class Activity
{
    [JsonPropertyName("activities-heart")]
    public List<HeartRateZoneGroup> ActivitiesHeart { get; set; } = null!;
    [JsonPropertyName("activities-heart-intraday")]
    public ActivitiesHeartIntraday ActivitiesHeartIntraday { get; set; } = null!;
    public string StartTime => DateHelper.JoinDateTimeAndTimeOnly(ActivitiesHeart.First().DateTime, ActivitiesHeartIntraday.Dataset.First().Time);
    
    public int Duration
    {
        get
        {
            var start = ActivitiesHeartIntraday.Dataset.First().Time;
            var end = ActivitiesHeartIntraday.Dataset.Last().Time;
            var span = end - start;
            return Convert.ToInt32(span.TotalSeconds);
        }
    }
    public int TotalCaloriesOut
    {
        get
        {
            return Convert.ToInt32(ActivitiesHeart.First().HeartRateZones.Sum(x => x.CaloriesOut));
        }
    }
}
public record ActivitiesHeartIntraday(int DatasetInterval, List<Record> Dataset, string DatasetType);
public record Record(TimeOnly Time, int Value)
{
    public string GetFullTime(DateTime date)=>DateHelper.JoinDateTimeAndTimeOnly(date, Time);
};

