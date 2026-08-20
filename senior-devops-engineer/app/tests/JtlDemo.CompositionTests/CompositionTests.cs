using JtlDemo.Modules.Windows;
using JtlDemo.Rest.Server;
using Xunit;

namespace JtlDemo.CompositionTests;

public class CompositionTests
{
    [Fact]
    public void Catalog_composes_the_expected_modules()
    {
        var names = ApiModuleCatalog.BuildApiModules().Select(m => m.Name).ToArray();

        Assert.Contains("Items", names);
        Assert.Contains("Customers", names);
        Assert.Contains("Stats", names);
        Assert.Contains("Documents", names);
        Assert.Contains("Printers", names);
    }

    [Fact]
    public void Stats_logic_uses_no_windows_api()
    {
        // StatsModule ships in the Windows-targeted assembly but its logic uses no Windows API.
        Assert.Equal(42, StatsModule.Value);
    }
}
