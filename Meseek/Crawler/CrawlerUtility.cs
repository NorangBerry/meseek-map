namespace Meseek.Crawler;

using Meseek.Crawler.BlueRibbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal static class CrawlerUtility
{

    public static string ConvertKR(this RibbonKindType ribbonKind)
    {
        return ribbonKind switch
        {
            RibbonKindType.NOT => "리본 0개",
            RibbonKindType.RIBBON_ONE => "리본 1개",
            RibbonKindType.RIBBON_TWO => "리본 2개",
            RibbonKindType.RIBBON_THREE => "리본 3개",
            RibbonKindType.NOT_RECORD => "미수록",
            RibbonKindType.ATTENTION => "미수록",
            RibbonKindType.NEW => "미수록",
            _ => throw new NotImplementedException(),
        };
    }
}
