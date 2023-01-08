namespace Meseek.Crawler.BlueRibbon;
using Newtonsoft.Json;

[JsonConverter(typeof(JsonPathConverter))]
internal class BlueRibbonResponseUnitInfo
{
    [JsonProperty("id")]
    public int Id { get; init; }

    [JsonProperty("headerInfo.nameKR")]
    public string Name { get; init; }

    [JsonProperty("headerInfo.year")]
    public int Year { get; init; }

    [JsonProperty("headerInfo.bookYear")]
    public int BookYear { get; init; }

    [JsonProperty("headerInfo.ribbonType")]
    public RibbonKindType RibbonType { get; init; }

    [JsonProperty("juso.roadAddrPart1")]
    public string NewAddress { get; init; }

    [JsonProperty("juso.jibunAddr")]
    public string OldAddress { get; init; }


    [JsonProperty("juso.detailAddress")]
    public string DetailAddress { get; init; }

    [JsonProperty("gps.latitude")]
    public float Longitude { get; init; }

    [JsonProperty("gps.longitude")]
    public float Latitude { get; init; }

    [JsonProperty("juso.zone2_1")]
    public string Zone1 { get; init; }

    [JsonProperty("juso.zone2_2")]
    public string Zone2 { get; init; }
}
