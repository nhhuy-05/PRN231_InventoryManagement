using System.Net.Http.Headers;
using System.Net;
using Client_InventoryManagement.DTO;

namespace Client_InventoryManagement.Services
{
    public class AccountService : BaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetToken(string username, string password)
        {
            var loginRequest = new LoginRequestDTO { Email = username, Password = password };
            var response = PushData<LoginRequestDTO>("Account/Login", loginRequest).Result;

            if (response == HttpStatusCode.OK)
            {
                var result = PushDataGetString<LoginRequestDTO>("Account/Login", loginRequest).Result;
                return result.ToString();
            }
            else
            {
                return null;
            }
        }

        public HttpStatusCode Register(string username, string password, string fullname)
        {
            var registerRequest = new RegisterRequestDTO { Email = username, Password = password, FullName = fullname };
            var response = PushData<RegisterRequestDTO>("Account/Register", registerRequest).Result;
            return response;
        }

        public HttpStatusCode Logout()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            string jwtToken = request.Cookies["jwtToken"];
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var url = "https://localhost:5000/api/Account/Logout";

                var response = client.PostAsync(url, null).Result;
                int statusCode = (int)response.StatusCode;

                return response.StatusCode;
            }
        }
    }
}
