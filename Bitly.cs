using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArticPolar.Dev.BitlyShortener
{
    public class BitlyShortener
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;

        public BitlyShortener(string accessToken)
        {
            _httpClient = new HttpClient();
            _accessToken = accessToken;
        }

        public async Task<string> ShortenUrl(string longUrl)
        {
            string apiUrl = "https://api-ssl.bitly.com/v4/shorten";

            var requestData = new
            {
                long_url = longUrl
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<BitlyShortenResponse>(responseJson);

                if (responseData != null)
                {
                    return responseData.id;
                }
            }

            MessageBox.Show("Failed to generate short link. Status code: " + response.StatusCode);
            return null;
        }
    }

    public class BitlyShortenResponse
    {
        public string id { get; set; }
    }
}
