using Azure.Storage.Blobs;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace QueueProcessorFunction;

public class JobProcessorFunction
{
    private readonly string blobConnectionString = Environment.GetEnvironmentVariable("BlobStorageConnection");
    private readonly string containerName = "uploaded-files";
     

    [Function(nameof(JobProcessorFunction))]
    public void Run([QueueTrigger("jobs", Connection = "QueueStorageConnection")] string jobMessage, ILogger log)
    {
        log.LogInformation($"Processing job: {jobMessage}");

        // simulate processing time
        Thread.Sleep(2000);

        // Upload a sample file to Blob Storage
        var blobServiceClient = new BlobServiceClient(blobConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        containerClient.CreateIfNotExists();

        var blobClient = containerClient.GetBlobClient($"file-{Guid.NewGuid()}.txt");
        using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jobMessage)))
        {
            blobClient.Upload(stream);
        }

        log.LogInformation($"Job processed and uploaded to Blob Storage: {jobMessage}");
    }
}