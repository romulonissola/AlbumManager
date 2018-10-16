using AlbumManager.Domain.Contracts.Integration.Utils;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlbumManager.Integration.Utils
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient _client;
        public HttpClientWrapper(string uri)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };
        }

        public async Task<T> GetAsync<T>(string path)
        {
            var result = await _client.GetAsync(path);
            result.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
        }
    }
}
