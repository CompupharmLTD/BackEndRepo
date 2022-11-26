using CompupharmLtd.Interface;
using Azure.Storage.Blobs;

namespace CompupharmLtd.Service
{
    public class BlobService : IBlob
    {
        public bool CheckIfExist()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete()
        {
            throw new System.NotImplementedException();
        }

        public bool Upload(string fileName)
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=compupharm;AccountKey=9dj5rmCC+T9irbgoaE5Lwh8jYK7s9AX+jsEhTzhWr3NHz4XycYj7znVDjJqMDchBbYhiysj4rrnc+AStGGmd4Q==;EndpointSuffix=core.windows.net";
            string containerName = "compupharmblob";
            var container = new BlobContainerClient(connectionString,containerName);

            var blob = container.GetBlobClient(fileName);


            throw new System.NotImplementedException();
        }
    }
}
