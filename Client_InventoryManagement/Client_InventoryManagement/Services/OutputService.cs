using Client_InventoryManagement.DTO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Client_InventoryManagement.Services
{
    public class OutputService : BaseService
    {
        public OutputService() { }

        public OutputResponseDTO AddOutput(OutputDTO outputDTO, string jwtToken)
        {
            string url = "https://localhost:5000/api/Output";
            HttpClient client = new HttpClient();
            if (jwtToken != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }
            var jsonStr = JsonSerializer.Serialize(outputDTO);
            HttpContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var result = responseMessage.Content.ReadFromJsonAsync<OutputResponseDTO>().Result;
                return result;
            }
            else throw new Exception(responseMessage.StatusCode.ToString());
        }

        public HttpStatusCode AddOutputDetail(OutputDetailRequestDTO outputDetailRequestDTO, string jwtToken)
        {
            var response = PushData<OutputDetailRequestDTO>("OutputDetail", outputDetailRequestDTO, jwtToken).Result;
            return response;
        }
    }
}
