using Client_InventoryManagement.DTO;
using System.Net;

namespace Client_InventoryManagement.Services
{
    public class CustomerService : BaseService
    {
        public CustomerService() { }
        public List<CustomerDTO> GetCustomers(string jwtToken)
        {
            var response = GetData<List<CustomerDTO>>("Customer", jwtToken).Result;
            return response;
        }

        public HttpStatusCode AddCustomer(CustomerRequestDTO customer, string jwtToken)
        {
            var response = PushData<CustomerRequestDTO>("Customer", customer, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateCustomer(CustomerRequestDTO customer, string jwtToken)
        {
            var response = PutData<CustomerRequestDTO>("Customer", customer, jwtToken).Result;
            return response;
        }
    }
}
