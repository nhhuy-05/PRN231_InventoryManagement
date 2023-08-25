using Client_InventoryManagement.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Client_InventoryManagement.Services
{
    public class ReportService : BaseService
    {
        public async Task<GetInputPriceAndNumberOfInput> GetInputPriceAndNumberOfInput(string jwtToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var url = "https://localhost:5000/api/Report/GetInputPriceAndNumberOfInput";

                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var resultObject = JsonConvert.DeserializeObject<GetInputPriceAndNumberOfInput>(result);

                return resultObject;
            }
        }

        public async Task<GetOutputPriceAndNumberOfOutput> GetOutputPriceAndNumberOfOutput(string jwtToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var url = "https://localhost:5000/api/Report/GetOutputPriceAndNumberOfOutput";

                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var resultObject = JsonConvert.DeserializeObject<GetOutputPriceAndNumberOfOutput>(result);

                return resultObject;
            }
        }

        public async Task<GetNumberOfCustomerAndSupplier> GetNumberOfCustomerAndSupplier(string jwtToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var url = "https://localhost:5000/api/Report/GetNumberOfCustomerAndSupplier";

                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var resultObject = JsonConvert.DeserializeObject<GetNumberOfCustomerAndSupplier>(result);

                return resultObject;
            }
        }

        public async Task<GetNumberOfProduct> GetNumberOfProduct(string jwtToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var url = "https://localhost:5000/api/Report/GetNumberOfProductInInventory";

                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var resultObject = JsonConvert.DeserializeObject<GetNumberOfProduct>(result);

                return resultObject;
            }
        }
    }
}
