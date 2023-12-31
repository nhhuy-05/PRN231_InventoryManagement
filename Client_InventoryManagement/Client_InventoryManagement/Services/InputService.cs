﻿using Client_InventoryManagement.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Client_InventoryManagement.Services
{
    public class InputService : BaseService
    {
        public InputService()
        {
        }

        public InputResponseDTO AddInput(InputDTO inputDTO, string jwtToken)
        {
            string url = "https://localhost:5000/api/Input";
            HttpClient client = new HttpClient();
            if (jwtToken != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }
            var jsonStr = JsonSerializer.Serialize(inputDTO);
            HttpContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var result = responseMessage.Content.ReadFromJsonAsync<InputResponseDTO>().Result;
                return result;
            }
            else throw new Exception(responseMessage.StatusCode.ToString());
        }

        public HttpStatusCode AddInputDetail(InputDetailRequestDTO inputDetailRequestDTO, string jwtToken)
        {
            var response = PushData<InputDetailRequestDTO>("InputDetail", inputDetailRequestDTO, jwtToken).Result;
            return response;
        }

    }
}
