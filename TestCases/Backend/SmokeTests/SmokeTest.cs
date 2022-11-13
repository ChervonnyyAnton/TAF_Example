using System;
using Keywords.Backend;
using DataProvider.Backend.DataObjects;
using RestSharp;

namespace TestCases.Backend
{
    public class PingPongTest
    {
        [Fact]
        public async Task IsServerAliveTest()
        {
            RestClient client = new RestClient("https://qa-scooter.praktikum-services.ru/api/v1/ping");
            RestRequest request = new RestRequest();
            CancellationToken cancellationToken = default;
            RestResponse response = await client.GetAsync(request, cancellationToken);
            string responseValue = response.Content.ToString();

            Assert.Equal("pong;", responseValue);
        }
    }
}