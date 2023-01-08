// See https://aka.ms/new-console-template for more information

namespace Meseek;

using Meseek.Crawler.BlueRibbon;
using System.Runtime.CompilerServices;


public class Program
{
    static async Task Main(string[] args)
    {
    }

    public static string GetThisFolderPath([CallerFilePath] string? path = null)
        => Path.GetDirectoryName(path)!;
}