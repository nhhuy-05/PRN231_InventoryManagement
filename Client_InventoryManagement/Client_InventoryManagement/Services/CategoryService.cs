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
        public CategoryDTO GetCategory(int id, string jwtToken)
        {
            var respone = GetData<CategoryDTO>("Category/" + id, jwtToken).Result;
            return respone;
        }

        public HttpStatusCode AddCategory(CategoryRequestDTO category, string jwtToken)
        {
            var response = PushData<CategoryRequestDTO>("Category", category, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateCategory(int id,CategoryRequestDTO category, string jwtToken)
        {
            var response = PutData<CategoryRequestDTO>("Category/"+id, category, jwtToken).Result;
            return response;
        }
    }
}
