using Newtonsoft.Json;

namespace Helpers
{
    public static class JsonSerializer
    {
        public static T? DeserializeResponse<T>(HttpResponseMessage response) where T : class
        {
            string json = ContentHandler.GetResponseContent(response);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string SerializeObject(object serializableObject)
        {
            return JsonConvert.SerializeObject(serializableObject);
        }
    }
}