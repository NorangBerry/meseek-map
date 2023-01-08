namespace Meseek.Crawler.BlueRibbon;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Immutable;
using Meseek;

internal class BlueRibbonCrawler
{
    private const string BlueRibbonUrl = "http://www.bluer.co.kr/api/v1/restaurants";

    private const int pageSize = 500;

    private Dictionary<int, BlueRibbonResponseUnitInfo> responseInfos = new();

    public async Task Crawl()
    {
        var page = 0;
        while(true)
        {
            var response = await Request(page);
            var infos = Parse(response);
            await Task.Delay(1000);
            foreach (var info in infos)
            {
                responseInfos.TryAdd(info.Id, info);
            }

            page ++;
            Console.WriteLine($"Crawl Item Count:{responseInfos.Count}. Current Page: {page}");

            if (infos.Count == 0)
            {
                break;
            }
        }

        Save();
    }

    private async Task<JObject> Request(int page)
    {
        // set query info 
        var queryInfo = new BlueRibbonQueryInfo(page, pageSize);

        // build query
        HttpClient client = new HttpClient();
        var queryParams = typeof(BlueRibbonQueryInfo).GetProperties().
            ToDictionary(
            property => char.ToLower(property.Name[0]) + property.Name.Substring(1), 
            property => property.GetValue(queryInfo)?.ToString() ?? string.Empty);
        var url = new Uri(QueryHelpers.AddQueryString(BlueRibbonUrl, queryParams));
        var response = await client.PostAsync(url, null);
        var content = await response.Content.ReadAsStringAsync();
        return JObject.Parse((content));
    }

    private IReadOnlyList<BlueRibbonResponseUnitInfo> Parse(JObject jobject)
    {
        var restaurants = jobject.
            GetValue("_embedded")?.
            ToObject<JObject>()?.
            GetValue("restaurants")?.
            ToObject<ImmutableList<BlueRibbonResponseUnitInfo>>();

        if(restaurants is null)
        {
            return ImmutableList.Create<BlueRibbonResponseUnitInfo>(); 
        }

        return restaurants;
    }

    private void Save()
    {
        var path = Path.Combine(Program.GetThisFolderPath(), "restaurants.json");
        using (StreamWriter file = File.CreateText(path))
        {
            var infos = responseInfos.Values.OrderBy(info => info.Id).Select(info => new BlueRibbonInfo(info));
            string json = JsonConvert.SerializeObject(infos, Formatting.Indented);
            //serialize object directly into file stream
            file.Write(json);
        }

        Console.WriteLine($"Save To {path}");
    }
}
