using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MyApp.Services
{
    public class FacebookService
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;

        public FacebookService(HttpClient httpClient, string accessToken)
        {
            _httpClient = httpClient;
            _accessToken = accessToken;
        }

        public async Task<JArray> GetGroupPostsAsync(string groupId)
        {
            var url = $"https://graph.facebook.com/{groupId}/feed?access_token={_accessToken}";
            var response = await _httpClient.GetStringAsync(url);
            var jsonResponse = JObject.Parse(response);
            return (JArray)jsonResponse["data"];
        }
    }
}
