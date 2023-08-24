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
        public SupplierDTO GetSupplier(int id,string jwtToken)
        {
            var respone = GetData<SupplierDTO>("Supplier/" + id, jwtToken).Result;
            return respone;
        }
        public HttpStatusCode AddSupplier(SupplierRequestDTO supplier, string jwtToken)
        {
            var response = PushData<SupplierRequestDTO>("Supplier", supplier, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateSupplier(int id,SupplierRequestDTO supplier, string jwtToken)
        {
            var response = PutData<SupplierRequestDTO>("Supplier/"+id, supplier, jwtToken).Result;
            return response;
        }
    }
}
