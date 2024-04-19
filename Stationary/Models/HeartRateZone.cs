namespace Stationary.Models
{
    public record HeartRateZone(double CaloriesOut, int Max, int Min, int Minutes, string Name);
    public record HeartRateZoneGroup(IEnumerable<HeartRateZone> CustomHeartRateZones, DateTime DateTime, IEnumerable<HeartRateZone> HeartRateZones, string Value);
}
