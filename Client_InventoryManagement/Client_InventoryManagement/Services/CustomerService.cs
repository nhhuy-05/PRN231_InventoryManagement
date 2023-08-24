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
        public CustomerDTO GetCustomer(int id, string jwtToken)
        {
            var respone = GetData<CustomerDTO>("Customer/" + id, jwtToken).Result;
            return respone;
        }

        public HttpStatusCode AddCustomer(CustomerRequestDTO customer, string jwtToken)
        {
            var response = PushData<CustomerRequestDTO>("Customer", customer, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateCustomer(int id, CustomerRequestDTO customer, string jwtToken)
        {
            var response = PutData<CustomerRequestDTO>("Customer?id="+id, customer, jwtToken).Result;
            return response;
        }
    }
}
