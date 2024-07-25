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
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request to Facebook API failed with status code {response.StatusCode}. Response: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JObject.Parse(responseContent);
            return (JArray)jsonResponse["data"];
        }

        public async Task<JObject> GetUserProfileAsync()
        {
            var url = $"https://graph.facebook.com/me?fields=id,name,picture&access_token={_accessToken}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request to Facebook API failed with status code {response.StatusCode}. Response: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JObject.Parse(responseContent);
            return jsonResponse;
        }
    }
}
