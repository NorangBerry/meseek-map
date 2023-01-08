namespace Meseek.Importer.Google;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

[XmlRoot(ElementName = "Placemark", Namespace = "http://www.opengis.net/kml/2.2")]
public class GoogleMapPlaceMark
{
    public GoogleMapPlaceMark()
    {

    }

    public GoogleMapPlaceMark(
        string name,
        string address,
        string? description,
        string? styleUrl,
        float latitude,
        float longitude,
        IReadOnlyDictionary<string, string> extendedData)
    {
        Name = name;
        Address = address;
        Description = description;
        StyleUrl = styleUrl;
        Latitude = latitude;
        Longitude = longitude;
        ExtendedData = extendedData.
            Select(pair=>  new ExtendedData(){ Name = pair.Key, Value = pair.Value }).
            ToList();
    }

    [XmlElement(ElementName = "name")]
    public string Name { get; init; }

    [XmlElement(ElementName = "address")]
    public string Address { get; init; }
    
    [XmlElement(ElementName = "description")]
    public string? Description { get; init; }
    
    [XmlElement(ElementName = "styleUrl")]
    public string? StyleUrl { get; init; }
    
    [XmlElement(ElementName = "latitude")]
    public float Latitude { get; init; }
    
    [XmlElement(ElementName = "longitude")]
    public float Longitude { get; init; }

    [XmlArray]
    public List<ExtendedData> ExtendedData { get; }
}

[XmlType(TypeName = "Data")]
public class ExtendedData
{
    [XmlAttribute(AttributeName = "name")]
    public string Name { get; init; }

    [XmlElement(ElementName = "value")]
    public string Value { get; init; }
}