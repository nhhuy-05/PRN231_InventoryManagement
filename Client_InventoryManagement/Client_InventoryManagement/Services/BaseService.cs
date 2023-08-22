using System.Net.Http.Headers;
using System.Net;
using System.Text.Json;
using System.Text;

namespace Client_InventoryManagement.Services
{
    public class BaseService
    {
        private string? _rootUrl;
        public BaseService()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _rootUrl = config.GetSection("ApiUrls")["MyApi"];
        }

        public async Task<T?> GetData<T>(string url, string? jwt = null, string? accepttype = null)
        {
            // get token from cookie
            T? result = default(T);
            HttpClient client = new HttpClient();
            url = _rootUrl + url;
            if (jwt != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (responseMessage.Content is not null)
                    result = responseMessage.Content.ReadFromJsonAsync<T>().Result;
                return result;
            }
            else throw new Exception(responseMessage.StatusCode.ToString());
        }

        public async Task<HttpStatusCode> PushData<T>(string url, T value, string? jwt = null, string? accepttype = null)
        {
            url = _rootUrl + url;
            HttpClient client = new HttpClient();
            if (jwt != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }
            var jsonStr = JsonSerializer.Serialize(value);

            HttpContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(url, content);
            return responseMessage.StatusCode;
        }

        public async Task<string> PushDataGetString<T>(string url, T value, string? jwt = null, string? accepttype = null)
        {
            url = _rootUrl + url;
            HttpClient client = new HttpClient();
            if (jwt != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }
            var jsonStr = JsonSerializer.Serialize(value);
            HttpContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(url, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                string responseContent = await responseMessage.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                // Handle other cases, throw an exception, etc.
                throw new Exception("Request failed with status code: " + responseMessage.StatusCode);
            }
        }

        public async Task<string> GetDataGetString<T>(string url, string? jwt = null, string? accepttype = null)
        {
            // get token from cookie
            HttpClient client = new HttpClient();
            url = _rootUrl + url;
            if (jwt != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseContent = await responseMessage.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                // Handle other cases, throw an exception, etc.
                throw new Exception("Request failed with status code: " + responseMessage.StatusCode);
            }
        }
    }
}
