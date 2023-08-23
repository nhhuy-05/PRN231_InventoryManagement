using Client_InventoryManagement.DTO;
using System.Net;

namespace Client_InventoryManagement.Services
{
    public class CategoryService : BaseService
    {
        public CategoryService()
        {
        }

        public List<CategoryDTO> GetCategories(string jwtToken)
        {
            var response = GetData<List<CategoryDTO>>("Category",jwtToken).Result;
            return response;
        }

        public HttpStatusCode AddCategory(CategoryRequestDTO category, string jwtToken)
        {
            var response = PushData<CategoryRequestDTO>("Category", category, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateCategory(CategoryRequestDTO category, string jwtToken)
        {
            var response = PutData<CategoryRequestDTO>("Category", category, jwtToken).Result;
            return response;
        }
    }
}
