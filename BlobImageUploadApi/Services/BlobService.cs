using Azure.Storage.Blobs;

namespace BlobImageUploadApi.Services
{
    public class BlobService
    {
        private readonly string _connectionString;
        private const string ContainerName = "images";

        public BlobService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BlobStorage");
        }

        public async Task UploadAsync(IFormFile file)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);

            var containerClient =
                blobServiceClient.GetBlobContainerClient(ContainerName);

            var blobClient = containerClient.GetBlobClient(file.FileName);

            using var stream = file.OpenReadStream();

            await blobClient.UploadAsync(stream, overwrite: true);
        }
    }
}
