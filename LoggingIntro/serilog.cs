
using Serilog;
using Serilog.Core;

Serilog.ILogger logger = new LoggerConfiguration()
        .CreateLogger();

        logger.Information("Hello world");