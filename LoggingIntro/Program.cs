using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

#region secret 🤭

using var loggerFactory = LoggerFactory.Create(builder =>
{
#pragma warning disable CA1416
    builder
        .AddJsonConsole();
#pragma warning restore CA1416
});

using var loggerFactory = LoggerFactory.Create(builder => 
{
    builder.AddJsonConsole(Options =>
    {
        options.IncludeScopes = false;
        options.TimestampFormat = "HH:mm:ss";
        options.JsonWriteOptions = new JsonWriterOptions{
            Intended = true
        };
    });
});

ILogger CreateLogger()
{
    return loggerFactory.CreateLogger("Course");
}
#endregion

using IHost host = Host.CreateDefaultBuilder(args)
.ConfigureLogging(x =>
    {
        x.AddJsonConsole();
    }
)
.Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogCritical("Critical msg...");

host.Run();

Microsoft.Extensions.Logging.ILogger logger = CreateLogger();

logger.LogInformation("Hello world");
logger.LogCritical("This is a critical message warning");
logger.LogDebug("Tis is a debug message");
logger.LogTrace("This is a trace call message");
var age = 25;


//The logger actually has only 2 methods more of Log as an imp one
//the others are just decontructing the same
logger.LogInformation($"Vishal just turned "); //string interpolation
logger.Log(LogLevel.Debug, 0, "Hello World!");

logger.LogInformation(LogEvents.UserBirthday, "{Name} just turned : {Age}", name, age)