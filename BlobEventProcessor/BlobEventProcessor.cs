using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

public static class BlobEventProcessor
{
    [FunctionName("BlobEventProcessor")]
    public static void Run(
        [EventGridTrigger] object eventGridEvent,
        ILogger log)
    {
        log.LogInformation($"Event received: {eventGridEvent}");
    }
}