using Newtonsoft.Json;

namespace Meseek.Crawler.BlueRibbon;

internal class BlueRibbonInfo
{
    public BlueRibbonInfo(BlueRibbonResponseUnitInfo info)
    {
        Url = $"www.bluer.co.kr/restaurants/{info.Id}";
        Name = info.Name;
        Year = info.Year > 1900 && info.Year < 3000 ? info.Year : null;
        BookYear = info.BookYear > 1900 && info.BookYear < 3000 ? info.BookYear : null;
        RibbonType = info.RibbonType.ToString();
        NewAddress = info.NewAddress;
        OldAddress = info.OldAddress;
        DetailAddress = info.DetailAddress;
        Longitude = info.Longitude;
        Latitude = info.Latitude;
        Zone1 = info.Zone1;
        Zone2 = info.Zone2;
    }

    [JsonProperty("Url")]
    string Url { get; init; }

    [JsonProperty("Name")]
    string Name { get; init; }
    
    [JsonProperty("Year")]
    int? Year { get; init; }

    [JsonProperty("BookYear")]
    int? BookYear { get; init; }

    [JsonProperty("RibbonType")]
    string RibbonType { get; init; }
    
    [JsonProperty("NewAddress")]
    string NewAddress { get; init; }

    [JsonProperty("OldAddress")]
    string OldAddress { get; init; }

    [JsonProperty("DetailAddress")]
    string DetailAddress { get; init; }

    [JsonProperty("Longitude")]
    float Longitude { get; init; }

    [JsonProperty("Latitude")]
    float Latitude { get; init; }

    [JsonProperty("Zone1")]
    string Zone1 { get; init; }

    [JsonProperty("Zone2")]
    string Zone2 { get; init; }
}
