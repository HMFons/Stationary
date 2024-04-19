using Stationary.Models;
using System.Text.Json;
using System.Xml.Linq;

Console.WriteLine("Latitude: ");
var latitude = Console.ReadLine();
Console.WriteLine("Longitude: ");
var longitude = Console.ReadLine();
Console.WriteLine("File:");
var fileName = Console.ReadLine();

if (latitude is null || longitude is null || fileName is null)
{
    Console.WriteLine("Bad input");
    Environment.Exit(400);
}
string jsonString = File.ReadAllText(fileName);
Console.WriteLine(jsonString);
var activity = JsonSerializer.Deserialize<Activity>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

XNamespace nsGarmin = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2";
XNamespace nsXml = "http://www.w3.org/2001/XMLSchema-instance";

XDocument doc = new(new XElement(nsGarmin + "TrainingCenterDatabase",
    new XElement(nsGarmin + "Activities",
        new XElement(nsGarmin + "Activity", new XAttribute("Sport", "Other"),
            new XElement(nsGarmin + "Id", activity.StartTime),
            new XElement(nsGarmin + "Lap", new XAttribute("StartTime", activity.StartTime),
                new XElement(nsGarmin + "TotalTimeSeconds", activity.Duration),
                new XElement(nsGarmin + "Calories", activity.TotalCaloriesOut),
                new XElement(nsGarmin + "Intensity", "Active"),
                new XElement(nsGarmin + "TriggerMethod", "Manual"),
                new XElement(nsGarmin + "Track",
                activity.ActivitiesHeartIntraday.Dataset.Select(record =>
                    new XElement(nsGarmin + "Trackpoint",
                        new XElement(nsGarmin + "Time", record.GetFullTime(activity.ActivitiesHeart.First().DateTime)),
                        new XElement(nsGarmin + "Position",
                            new XElement(nsGarmin + "LatitudeDegrees", latitude),
                            new XElement(nsGarmin + "LongitudeDegrees", longitude)),
                        new XElement(nsGarmin + "AltitudeMeters", "0"),
                        new XElement(nsGarmin + "DistanceMeters", "0"),
                        new XElement(nsGarmin + "HeartRateBpm",
                            new XElement(nsGarmin + "Value", record.Value))
                    )
                )),
                new XElement(nsXml + "Creator", new XAttribute("type", "Device_t"),
                    new XElement(nsXml + "UnitId", 0),
                    new XElement(nsXml + "ProductID", 0)
                ))))));

var xmlDoc = doc.ToString();
Console.WriteLine(xmlDoc);
doc.Save(fileName.Split('.')[0] + ".tcx");
Console.ReadLine();
