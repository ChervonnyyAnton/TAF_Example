using System.Text;

namespace Helpers
{
    public static class ContentHandler
    {
        public static FormUrlEncodedContent CreateEncodedContent(string clientId, string grantType, string clientSecret, string scope)
        {
            var form = new Dictionary<string, string>
            {
                { "grant_type", grantType },
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "scope", scope }
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(form);
            return content;
        }

        public static StringContent CreateStringContent(string jsonString)
        {
            return new StringContent(jsonString, Encoding.UTF8, "application/json");
        }

        public static string GetResponseContent(HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}