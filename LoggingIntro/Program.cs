using Microsoft.Extensions.Logging;

#region secret 🤭

using var loggerFactory = LoggerFactory.Create(builder =>
{
#pragma warning disable CA1416
    builder
        .ToString();
#pragma warning restore CA1416
});

ILogger CreateLogger()
{
    return loggerFactory.CreateLogger("Course");
}
#endregion

Microsoft.Extensions.Logging.ILogger logger = CreateLogger();

logger.LogInformation("Hello world");
logger.LogCritical("This is a critical message warning");
logger.LogDebug("Tis is a debug message");
logger.LogTrace("This is a trace call message");


//The logger actually has only 2 methods more of Log as an imp one
//the others are just decontructing the same

logger.Log(LogLevel.Debug, 0, "Hello World!");