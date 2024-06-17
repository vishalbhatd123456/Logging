
using Microsoft.ApplicationInsights.Channel;

using var channel = new InMemoryChannel();

try
{
    //using Dependency Injection extension - step 2
    IServiceCollection services = new ServiceCollection();
    services.Configure<TelemetryConfigurion>(x => x.TelemetryChannel = channel);
    services.AddLogging(x => 
    {
        x.ApplicationInsights(
            configureTelemetryConfiguraton : teleConfig =>
                teleConfig.ConnectionString = 
                    "config string from the application insights"
                    configureAllicationInsightsLoggerOptions: _ => {}
        );
    });

    var serviceProvider = services.BuildServiceProvider();

    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("Hello World");
}
finally
{
    await channel.FlushAsync(); //first step to flush the buffer of application memory into app insigths
    await Task.Delay(1000);
}