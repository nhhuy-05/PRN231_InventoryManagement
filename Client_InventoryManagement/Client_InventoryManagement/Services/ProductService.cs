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
        public ProductDTO GetProduct(int id, string jwtToken)
        {
            var respone = GetData<ProductDTO>("Product/" + id, jwtToken).Result;
            return respone;
        }

        public HttpStatusCode AddProduct(ProductRequestDTO product, string jwtToken)
        {
            var response = PushData<ProductRequestDTO>("Product", product, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateProduct(int id, ProductRequestDTO product, string jwtToken)
        {
            var response = PutData<ProductRequestDTO>("Product/"+id, product, jwtToken).Result;
            return response;
        }
    }
}
