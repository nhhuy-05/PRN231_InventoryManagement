using Client_InventoryManagement.DTO;
using System.Net;

namespace Client_InventoryManagement.Services
{
    public class CategoryService : BaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<CategoryDTO> GetCategories()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            string jwtToken = request.Cookies["jwtToken"];
            var response = GetData<List<CategoryDTO>>("Category",jwtToken).Result;
            return response;
        }

        public HttpStatusCode AddCategory(CategoryRequestDTO category)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            string jwtToken = request.Cookies["jwtToken"];
            var response = PushData<CategoryRequestDTO>("Category", category, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateCategory(CategoryRequestDTO category)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            string jwtToken = request.Cookies["jwtToken"];
            var response = PutData<CategoryRequestDTO>("Category", category, jwtToken).Result;
            return response;
        }
    }
}
