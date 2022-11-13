using System;
using DataProvider.Backend;
using DataProvider.Backend.DataObjects;

namespace Keywords.Backend
{
    public static class Endpoint
    {
        public static async Task<HttpResponseMessage> PingAsync()
        {
            return await ClientProvider.Get(CoreKeywords.BuildPingUrl());
        }

        public static async Task<HttpResponseMessage> CreateOrder(Order order)
        {
            return await ClientProvider.Post(CoreKeywords.BuildNewOrderUrl(), order);
        }

        public static async Task<HttpResponseMessage> CreateUser(User user)
        {
            return await ClientProvider.Post(CoreKeywords.BuildNewOrderUrl(), user);
        }
    }
}