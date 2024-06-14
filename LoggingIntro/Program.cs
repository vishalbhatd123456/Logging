using Microsoft.Extensions.Logging;

#region explore_later
using var loggerFactory = LoggerFactory.Create(builder =>
    builder.AddConsole();
#pragma warning restore C1416
});

ILogger CreateLogger()
{
    return loggerFactory.CreateLogger("Course");
}
#endregion

ILogger logger = CreateLogger();