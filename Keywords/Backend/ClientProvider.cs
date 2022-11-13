using System;
using System.Net.Http.Headers;
using Helpers;

namespace DataProvider.Backend
{
    public static class ClientProvider
    {
        public static HttpClient CreateClient(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            return client;
        }

        public static async Task<HttpResponseMessage> Post(string url, object serializableObject)
        {
            HttpClient client = CreateClient(url);
            string jsonString = JsonSerializer.SerializeObject(serializableObject);
            StringContent stringContent = ContentHandler.CreateStringContent(jsonString);
            return await client.PostAsync(client.BaseAddress, stringContent);
        }

        public static async Task<HttpResponseMessage> Get(string url)
        {
            HttpClient client = CreateClient(url);
            return await client.GetAsync(client.BaseAddress);
        }

        public static async Task<HttpResponseMessage> Delete(string url)
        {
            HttpClient client = CreateClient(url);
            return await client.DeleteAsync(client.BaseAddress);
        }
    }
}