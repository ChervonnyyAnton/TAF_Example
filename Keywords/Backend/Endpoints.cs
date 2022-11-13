using System;
using DataProvider.Backend;
using DataProvider.Backend.DataObjects;
using RestSharp;

namespace Keywords.Backend
{
    public static class Endpoint
    {
        public static async Task<RestResponse> PingAsync()
        {
            return await ClientProvider.Get(CoreKeywords.BuildPingUrl());
        }

        public static async Task<RestResponse> CreateOrder(Order order)
        {
            return await ClientProvider.Post(CoreKeywords.BuildNewOrderUrl(), order);
        }
    }
}