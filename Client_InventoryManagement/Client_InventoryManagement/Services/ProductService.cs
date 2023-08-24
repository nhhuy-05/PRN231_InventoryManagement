using Client_InventoryManagement.DTO;
using System.Net;

namespace Client_InventoryManagement.Services
{
    public class ProductService : BaseService
    {
        public ProductService() { }

        public List<ProductDTO> GetAllProducts(string jwtToken)
        {
            var response = GetData<List<ProductDTO>>("Product", jwtToken).Result;
            return response;
        }

        public HttpStatusCode AddProduct(ProductRequestDTO product, string jwtToken)
        {
            var response = PushData<ProductRequestDTO>("Product", product, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateProduct(ProductDTO product, string jwtToken)
        {
            var response = PutData<ProductDTO>("Product", product, jwtToken).Result;
            return response;
        }
    }
}
