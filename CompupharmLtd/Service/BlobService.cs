using CompupharmLtd.Interface;
using Azure.Storage.Blobs;
using System.Text;
using System.IO;
using Azure.Storage.Blobs.Models;
using System;
using Azure;

namespace CompupharmLtd.Service
{
    public static class BlobService 
    {
        public static string GetBlob(string fileName)
        {

            var connectionString = "DefaultEndpointsProtocol=https;AccountName=compupharm;AccountKey=9dj5rmCC+T9irbgoaE5Lwh8jYK7s9AX+jsEhTzhWr3NHz4XycYj7znVDjJqMDchBbYhiysj4rrnc+AStGGmd4Q==;EndpointSuffix=core.windows.net";
            string containerName = "compupharmblob";
            var container = new BlobServiceClient(connectionString);

            var containerClient = container.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            try
            {
                var blobDownloadInfo =  blobClient.DownloadContent();
                string blob = blobDownloadInfo.Value.Content.ToString();
                return blob;
            }
            catch (RequestFailedException) { }
            return "";
            }

        public static bool Delete(string fileName)
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=compupharm;AccountKey=9dj5rmCC+T9irbgoaE5Lwh8jYK7s9AX+jsEhTzhWr3NHz4XycYj7znVDjJqMDchBbYhiysj4rrnc+AStGGmd4Q==;EndpointSuffix=core.windows.net";
            string containerName = "compupharmblob";
            var container = new BlobServiceClient(connectionString);

            var containerClient = container.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            try
            {
                blobClient.DeleteIfExists();
            }catch(RequestFailedException ex)
            {
                throw;
            }
            return true;
            }

        public static bool Upload(string fileName, string content)
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=compupharm;AccountKey=9dj5rmCC+T9irbgoaE5Lwh8jYK7s9AX+jsEhTzhWr3NHz4XycYj7znVDjJqMDchBbYhiysj4rrnc+AStGGmd4Q==;EndpointSuffix=core.windows.net";
            string containerName = "compupharmblob";
            var container = new BlobServiceClient(connectionString);

            var containerClient = container.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            var bytes = Encoding.UTF8.GetBytes(content);
           using var memoryStream = new MemoryStream(bytes);
            try
            {
                blobClient.Upload(memoryStream);//, new BlobHttpHeaders { ContentType = fileName.GetContentType() });
            }catch(RequestFailedException ex)
            {
                if (ex.Status == 409)
                {
                    try
                    {
                        blobClient.DeleteIfExists();
                        memoryStream.Position = 0;
                        blobClient.Upload(memoryStream);
                    }
                    catch (RequestFailedException e)
                    {
                        throw;
                    }
                }
            }
            return true;
          //  throw new System.NotImplementedException();
        }
    }
}
