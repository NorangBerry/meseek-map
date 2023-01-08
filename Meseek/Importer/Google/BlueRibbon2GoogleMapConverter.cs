namespace Meseek.Importer.Google;

using Meseek.Crawler;
using Meseek.Crawler.BlueRibbon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

internal class BlueRibbon2GoogleMapConverter
{
    public const string Name = "블루리본 지도";

    public static void Run() 
    {
        var infos = BlueRibbonCrawler.Load();
        Save(Convert(infos));
    }

    private static IReadOnlyList<GoogleMapPlaceMark> Convert(IReadOnlyList<BlueRibbonInfo> blueRibbonInfos)
    {
        return blueRibbonInfos.
            Select(info =>
            {
                var extendedData = new Dictionary<string, string>()
                {
                    {"링크", info.Url},
                    {"등급", info.RibbonType.ConvertKR()},
                    {"수록년도", info.Name},
                };

                return new GoogleMapPlaceMark(
                    info.Name,
                    info.DetailAddress == string.Empty ? info.NewAddress : $"{info.NewAddress} {info.DetailAddress}",
                    null,
                    null,
                    info.Latitude,
                    info.Longitude,
                    extendedData);
            }).
            ToList();
    }

    private static void Save(IReadOnlyList<GoogleMapPlaceMark> marks)
    {

        var path = Path.Combine(Program.GetThisFolderPath(), "mapPoints.kml");
        using (var file = File.CreateText(path))
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GoogleMapPlaceMark));

            XmlWriterSettings settings = new()
            {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                NewLineOnAttributes = false,
            };

            var xmlWriter = XmlWriter.Create(file, settings);

            xmlWriter.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
            xmlWriter.WriteStartElement("Document");
            xmlWriter.WriteElementString("name",Name);
            xmlWriter.WriteElementString("description", $"Last Updated: {DateTime.Now.Date.ToString("yyyy/MM/dd")}");
            xmlWriter.WriteStartElement("Folder");
            xmlWriter.WriteElementString("name",Name);
            foreach (var mark in marks)
            {
                ////TODO: xmlns 제거
                xmlSerializer.Serialize(xmlWriter, mark);
                
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}
