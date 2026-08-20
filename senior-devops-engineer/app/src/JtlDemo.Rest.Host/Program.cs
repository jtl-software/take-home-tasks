using System.Diagnostics;
using JtlDemo.Rest.Server;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Legacy configuration: the connection profile comes from the Windows registry.
// This throws on any non-Windows host, so the container cannot start as-is.
using var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JTL\Wawi");
var connectionString = key?.GetValue("ConnectionString") as string
    ?? throw new InvalidOperationException(@"Missing HKLM\SOFTWARE\JTL\Wawi\ConnectionString");

// Legacy diagnostics: startup is written to the Windows Event Log.
EventLog.WriteEntry("Application", "JtlDemo REST host starting", EventLogEntryType.Information);

app.MapGet("/healthz", () => Results.Ok(new { status = "ok" }));
app.MapGet("/api/_config", () => Results.Ok(new { configured = connectionString.Length > 0 }));

foreach (var module in ApiModuleCatalog.BuildApiModules())
{
    module.MapEndpoints(app);
}

app.Run();
