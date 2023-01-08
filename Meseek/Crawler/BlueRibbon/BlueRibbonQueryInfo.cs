namespace Meseek.Crawler.BlueRibbon;

internal class BlueRibbonQueryInfo
{
    public BlueRibbonQueryInfo(int page, int size)
    {
        Page = page;
        Size = size;
    }

    public int Page { get; init; }
    public int Size { get; init; }
    public string Query { get; } = string.Empty;
    public string FoodType { get; } = string.Empty;
    public string FoodTypeDetail { get; } = string.Empty;
    public string Feature { get; } = string.Empty;
    public string Location { get; } = string.Empty;
    public string LocationDetail { get; } = string.Empty;
    public string Area { get; } = string.Empty;
    public string AreaDetail { get; } = string.Empty;
    public string PriceRange { get; } = string.Empty;
    public RibbonKindType? RibbonType { get; }
    public bool Recommended { get; } = false;
    public bool IsSearchName { get; } = false;
    public TabModeKindType TabMode { get; } = TabModeKindType.single;
    public SearchModeKindType SearchMode { get; } = SearchModeKindType.ribbonType;

    public string Zone1 { get; } = string.Empty;
    public string Zone2 { get; } = string.Empty;
    public float? Zone2Lat { get; }
    public float? zone2Lng { get; }
}
