using Azure.Storage.Queues;

namespace BlobImageUploadApi.Services
{
    public class QueueService
    {
        private readonly QueueClient _queueClient;

        public QueueService(string connectionString,string queueName)
        {
            _queueClient = new QueueClient(connectionString,queueName);
            _queueClient.CreateIfNotExists();
        }

        public void EnqueueMessage(string message)
        {
            _queueClient.SendMessage(message);
        }

    }
}
