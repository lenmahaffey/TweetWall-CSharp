using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Net;
using System.Linq;
using Newtonsoft.Json;

namespace HTTPGetRequest
{
    class TwitterHttpGetRequest
    {
        public string Username { get; set; }
        public string Passphrase { get; set; }
        public string AuthToken { get; set; }
        private string bearerToken { get; set; }
        private Uri URL { get; set; }
        private string UrlOptions { get; set; }
        public TwitterHttpGetRequest(string u, string p)
        {
            Username = u;
            Passphrase = p;
            string authString = Username + ":" + Passphrase;
            byte[] stringBytes = System.Text.UTF8Encoding.UTF8.GetBytes(authString);
            bearerToken = System.Convert.ToBase64String(stringBytes);
        }

        private async Task<string> GetAuthTokenAsync()
        {
            var httpClient = new HttpClient();
            var authTokenRequest = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token ");
            authTokenRequest.Headers.Add("Authorization", "Basic " + bearerToken);
            authTokenRequest.Content = new StringContent("grant_type=client_credentials",
                                                 Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage authTokenResposne = await httpClient.SendAsync(authTokenRequest);

            string jsonResponse = await authTokenResposne.Content.ReadAsStringAsync();
            Dictionary<string, string> responseToken = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(jsonResponse);
            AuthToken = responseToken["access_token"];
            return responseToken["access_token"];
        }

        public async Task<string> GetTweetsAsync()
        {
            string token = await GetAuthTokenAsync();
            var httpClient = new HttpClient();
            var tweetRequest = new HttpRequestMessage(HttpMethod.Get, "https://api.twitter.com/1.1/search/tweets.json?q=%23Denver");
            tweetRequest.Headers.Add("Authorization",$"Bearer {AuthToken}");
            HttpResponseMessage tweetRequestResponse = await httpClient.SendAsync(tweetRequest);
            string jsonResponse = await tweetRequestResponse.Content.ReadAsStringAsync();
            var newton = JsonConvert.DeserializeObject< Dictionary<string, object>>(jsonResponse);
            string tweetString = newton["statuses"].ToString();
            string searchDataString = newton["search_metadata"].ToString();
            Console.WriteLine(tweetString);
            var tweets = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(tweetString);
            var searchData = JsonConvert.DeserializeObject<Dictionary<string, object>>(searchDataString);
            return "";
        }
    }
}
