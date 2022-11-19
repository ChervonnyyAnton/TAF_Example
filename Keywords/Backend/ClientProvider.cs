using Helpers;
using RestSharp;

namespace Keywords.Backend
{
    public static class ClientProvider
    {
        public static RestClient CreateRestClient(string url)
        {
            return new RestClient(url);
        }

        public static async Task<RestResponse> Post(string url, object serializableObject)
        {
            RestClient client = CreateRestClient(url);
            string requestBody = JsonSerializer.SerializeObject(serializableObject);
            RestRequest request = new RestRequest(requestBody);
            CancellationToken cancellationToken = default;
            RestResponse response = await client.PostAsync(request, cancellationToken);

            return response;
        }

        public static async Task<RestResponse> Get(string url)
        {
            RestClient client = CreateRestClient(url);
            RestRequest request = new RestRequest();
            CancellationToken cancellationToken = default;
            RestResponse response = await client.GetAsync(request, cancellationToken);

            return response;
        }

        public static async Task<RestResponse> Delete(string url, object? serializableObject)
        {
            string requestBody = String.Empty;

            if(serializableObject != null)
            {
                requestBody = JsonSerializer.SerializeObject(serializableObject);
            }

            RestClient client = CreateRestClient(url);
            RestRequest request = new RestRequest(requestBody);
            CancellationToken cancellationToken = default;
            RestResponse response = await client.DeleteAsync(request, cancellationToken);

            return response;
        }
    }
}