using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meseek.Crawler.BlueRibbon;

internal class BlueRibbonInfo
{
    public BlueRibbonInfo(BlueRibbonResponseUnitInfo info)
    {
        Url = $"www.bluer.co.kr/restaurants/{info.Id}";
        Name = info.Name;
        Year = info.Year > 1900 && info.Year < 3000 ? info.Year : null;
        BookYear = info.BookYear > 1900 && info.BookYear < 3000 ? info.BookYear : null;
        RibbonType = info.RibbonType;
        NewAddress = info.NewAddress;
        OldAddress = info.OldAddress;
        DetailAddress = info.DetailAddress;
        Longitude = info.Longitude;
        Latitude = info.Latitude;
        Zone1 = info.Zone1;
        Zone2 = info.Zone2;
    }

    public BlueRibbonInfo()
    {
    }

    public string Url { get; init; }

    public string Name { get; init; }
    
    public int? Year { get; init; }

    public int? BookYear { get; init; }

    [JsonConverter(typeof(StringEnumConverter))]
    public RibbonKindType RibbonType { get; init; }
    
    public string NewAddress { get; init; }

    public string OldAddress { get; init; }

    public string DetailAddress { get; init; }

    public float Longitude { get; init; }

    public float Latitude { get; init; }

    public string Zone1 { get; init; }

    public string Zone2 { get; init; }
}
