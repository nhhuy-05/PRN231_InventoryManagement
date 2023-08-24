using Client_InventoryManagement.DTO;
using System.Net;

namespace Client_InventoryManagement.Services
{
    public class SupplierService :BaseService
    {
        public SupplierService()
        {
        }

        public List<SupplierDTO> GetAllSuppliers(string jwtToken)
        {
            var response = GetData<List<SupplierDTO>>("Supplier", jwtToken).Result;
            return response;
        }

        public HttpStatusCode AddSupplier(SupplierRequestDTO supplier, string jwtToken)
        {
            var response = PushData<SupplierRequestDTO>("Supplier", supplier, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateSupplier(SupplierRequestDTO supplier, string jwtToken)
        {
            var response = PutData<SupplierRequestDTO>("Category", supplier, jwtToken).Result;
            return response;
        }
    }
}
