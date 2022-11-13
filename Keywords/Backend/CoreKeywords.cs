using System;
using DataProvider.Backend;


namespace Keywords.Backend
{
    public static class CoreKeywords
    {
        public static string BuildPingUrl()
        {
            return ClientCredentials.Url + "api/v1/ping";
        }

        public static string BuildNewOrderUrl()
        {
            return ClientCredentials.Url + "api/v1/orders";
        }
    }
}